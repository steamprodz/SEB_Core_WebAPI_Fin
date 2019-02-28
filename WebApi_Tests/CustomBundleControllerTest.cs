using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Contexts;
using SEB_Core_WebAPI.Controllers;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Repositories;
using SEB_Core_WebAPI.Services;
using SEB_Core_WebAPI.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Tests.FakeServices;
using Xunit;

namespace WebApi_Tests
{
    public class CustomBundlesControllerTest
    {
        public static string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=SEB;Integrated Security=True;";

        private readonly ICustomBundlesRepository customBundlesRepository;
        private readonly IBundlesRepository bundlesRepository;
        private readonly IQuestionsRepository questionsRepository;
        private readonly IProductsRepository productsRepository;

        private readonly DefaultContext _context;
        private readonly DbContextOptions<DefaultContext> _contextOptions;

        private readonly CustomBundlesController _controller;
        private readonly ICustomBundlesService _service;

        public CustomBundlesControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<DefaultContext>()
                .UseSqlServer(connectionString)
                .Options;

            _context = new DefaultContext(_contextOptions);

            customBundlesRepository = new CustomBundlesRepository(_context);
            bundlesRepository = new BundlesRepository(_context);
            questionsRepository = new QuestionsRepository(_context);
            productsRepository = new ProductsRepository(_context);

            _service = new CustomBundlesService(customBundlesRepository, bundlesRepository, questionsRepository, productsRepository);
            _controller = new CustomBundlesController(_service);
        }

        [Fact]
        public async Task Post_WhenCalledValidation_ReturnsOkResult()
        {
            // Arrange
            ValidateViewModel validateViewModel = new ValidateViewModel
            {
                CustomBundle = new CustomBundleViewModel
                {
                    Products = new ProductViewModel[]
                    {
                        new ProductViewModel { Name = "Student Account" },
                        new ProductViewModel { Name = "Debit Card" }
                    }
                },
                Question = new QuestionViewModel
                {
                    Age = 18,
                    IsStudent = true,
                    Income = 200
                }
            };

            // Act
            var result = await _controller.PostValidateCustomBundleAsync(validateViewModel);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_WhenCalledValidation_ReturnsConflictObjectResult()
        {
            // Arrange
            ValidateViewModel validateViewModel = new ValidateViewModel
            {
                CustomBundle = new CustomBundleViewModel
                {
                    Products = new ProductViewModel[]
                    {
                        new ProductViewModel { Name = "Student Account" },
                        new ProductViewModel { Name = "Current Account" },
                        new ProductViewModel { Name = "Debit Card" }
                    }
                },
                Question = new QuestionViewModel
                {
                    Age = 18,
                    IsStudent = true,
                    Income = 200
                }
            };

            // Act
            var result = await _controller.PostValidateCustomBundleAsync(validateViewModel);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        [Fact]
        public async Task Post_GetRecommendedBundle_ReturnsOkObjectResult()
        {
            // Arrange
            var questionViewModel = new QuestionViewModel
            {
                Age = 18,
                IsStudent = true,
                Income = 200
            };

            // Act
            var result = await _controller.PostRecommendedBundleAsync(questionViewModel);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task Post_GetRecommendedBundle_ReturnsStatusOk()
        {
            // Arrange
            var questionViewModel = new QuestionViewModel
            {
                Age = 18,
                IsStudent = true,
                Income = 200
            };

            // Act
            var result = (ObjectResult)await _controller.PostRecommendedBundleAsync(questionViewModel);

            // Assert
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Post_GetRecommendedBundle_ReturnsJSONResponse()
        {
            // Arrange
            var questionViewModel = new QuestionViewModel
            {
                Age = 18,
                IsStudent = true,
                Income = 200
            };

            // Act
            var result = (ObjectResult)await _controller.PostRecommendedBundleAsync(questionViewModel);

            var cbvm = (CustomBundleViewModel)result.Value;

            string[] productNames = cbvm.Products.Select(p => p.Name).ToArray();

            Assert.Equal(productNames, new string[] { "Current Account", "Debit Card" });
        }
    }
}
