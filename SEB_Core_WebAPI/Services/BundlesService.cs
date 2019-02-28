using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Services
{
    public class BundlesService : IBundlesService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IBundlesRepository _bundlesRepository;


        public BundlesService(IBundlesRepository bundlesRepository, IQuestionsRepository questionsRepository, IProductsRepository productsRepository)
        {
            _bundlesRepository = bundlesRepository;
            _questionsRepository = questionsRepository;
            _productsRepository = productsRepository;
        }

        //public async Task<IActionResult> GetRecommendedBundleAsync(int questionId)
        //{
        //    try
        //    {
        //        Bundle bundle = await _bundlesRepository.GetRecommendedBundleAsync(questionId);

        //        if (bundle != null)
        //        {
        //            return new OkObjectResult(new BundleViewModel()
        //            {
        //                Id = bundle.BundleId,
        //                // TODO
        //                ProductList = new List<ProductViewModel>(),
        //                Value = bundle.Value

        //                //Sku = p.Sku.Trim(),
        //                //Name = p.Name.Trim()
        //            });
        //        }
        //        else
        //        {
        //            return new NotFoundResult();
        //        }
        //    }
        //    catch
        //    {
        //        return new ConflictResult();
        //    }
        //}

        public async Task<IActionResult> PostRecommendedBundleAsync(Question question)
        {
            //if (question.Income > 0 && question.Age > 17)
            //{

            //}
            //else if (question.Income > 40000 && question.Age > 17)
            //{

            //}
            //else if (question.Age < 18)

            Bundle bundle = null;       

            if (question.Income > 40000 && question.Age > 17)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Gold");
            }
            else if (question.Income > 12000 && question.Age > 17)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Classic Plus");
            }
            else if (question.Age > 17 && question.Income > 0)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Classic");
            }
            else if (question.Age > 17 && question.IsStudent)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Student");
            }
            else if (question.Age < 18)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Junior Saver");
            }

            var products = await _bundlesRepository.GetBundleProductsAsync(bundle.BundleId);

            List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

            foreach (var item in products)
            {
                productViewModelList.Add(new ProductViewModel()
                {
                    Id = item.ProductId,
                    Name = item.Name
                });
            }

            return new OkObjectResult(productViewModelList);
        }

        public async Task<IActionResult> GetRecommendedBundleAsync(int questionId)
        {
            //try
            //{
                //Bundle bundle = await _bundlesRepository.GetRecommendedBundleAsync(questionId);
                Bundle bundle = await _bundlesRepository.GetBundleAsync(questionId);

                if (bundle != null)
                {
                    return new OkObjectResult(new BundleViewModel()
                    {
                        Id = bundle.BundleId,
                        Name = bundle.Name,
                        Value = bundle.Value

                        //Sku = p.Sku.Trim(),
                        //Name = p.Name.Trim()
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            //}
            //catch
            //{
            //    return new ConflictResult();
            //}
        }

        public async Task<IActionResult> GetAllBundlesAsync()
        {
            //try
            //{
                IEnumerable<Bundle> bundles = await _bundlesRepository.GetAllBundlesAsync();

                if (bundles != null)
                {
                    return new OkObjectResult(bundles.Select(b => new BundleViewModel()
                    {
                        Id = b.BundleId,
                        Name = b.Name,
                        Value = b.Value

                        //ProductType = p.ProductType.ToEnum<AccountCardType>(),
                        //Sku = p.Sku.Trim(),
                        //Name = p.Name.Trim()
                    }
                    ));
                }
                else
                {
                    return new NotFoundResult();
                }
            //}
            //catch
            //{
            //    return new ConflictResult();
            //}
        }

        public async Task<IActionResult> GetBundleAsync(int bundleId)
        {
            //try
            //{
                Bundle bundle = await _bundlesRepository.GetBundleAsync(bundleId);

                if (bundle != null)
                {
                    return new OkObjectResult(new BundleViewModel()
                    {
                        Id = bundle.BundleId,
                        Name = bundle.Name,
                        Value = bundle.Value
                        
                        //Sku = product.Sku.Trim(),
                        //Name = product.Name.Trim()
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            //}
            //catch (Exception ex)
            //{
            //    return new ConflictResult();
            //}
        }

        public async Task<IActionResult> DeleteBundleAsync(int bundleId)
        {
            //try
            //{
                Bundle bundle = await _bundlesRepository.DeleteBundleAsync(bundleId);

                if (bundle != null)
                {
                    return new OkObjectResult(new BundleViewModel()
                    {
                        Id = bundle.BundleId,
                        Name = bundle.Name,
                        Value = bundle.Value

                        //Sku = product.Sku.Trim(),
                        //Name = product.Name.Trim()
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            //}
            //catch
            //{
            //    return new ConflictResult();
            //}
        }
    }
}
