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
    public class CustomBundlesService : ICustomBundlesService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IBundlesRepository _bundlesRepository;
        private readonly ICustomBundlesRepository _customBundlesRepository;


        public CustomBundlesService(IBundlesRepository bundlesRepository, IQuestionsRepository questionsRepository, IProductsRepository productsRepository)
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

        //public async Task<IActionResult> PostRecommendedBundleAsync(Question question)
        //{
        //    //if (question.Income > 0 && question.Age > 17)
        //    //{

        //    //}
        //    //else if (question.Income > 40000 && question.Age > 17)
        //    //{

        //    //}
        //    //else if (question.Age < 18)

        //    Bundle bundle = null;       

        //    if (question.Income > 40000 && question.Age > 17)
        //    {
        //        bundle = await _bundlesRepository.FindBundleAsync("Gold");
        //    }
        //    else if (question.Income > 12000 && question.Age > 17)
        //    {
        //        bundle = await _bundlesRepository.FindBundleAsync("Classic Plus");
        //    }
        //    else if (question.Age > 17 && question.Income > 0)
        //    {
        //        bundle = await _bundlesRepository.FindBundleAsync("Classic");
        //    }
        //    else if (question.Age > 17 && question.IsStudent)
        //    {
        //        bundle = await _bundlesRepository.FindBundleAsync("Student");
        //    }
        //    else if (question.Age < 18)
        //    {
        //        bundle = await _bundlesRepository.FindBundleAsync("Junior Saver");
        //    }

        //    var products = await _bundlesRepository.GetBundleProductsAsync(bundle.BundleId);

        //    List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

        //    foreach (var item in products)
        //    {
        //        productViewModelList.Add(new ProductViewModel()
        //        {
        //            Id = item.ProductId,
        //            TypeName = item.Name
        //        });
        //    }

        //    return new OkObjectResult(productViewModelList);
        //}

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

        public async Task<IActionResult> PostRecommendedCustomBundleAsync(Question question)
        {
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

            //var products = await _bundlesRepository.GetBundleProductsAsync(bundle.BundleId);

            //List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

            //foreach (var item in products)
            //{
            //    productViewModelList.Add(new ProductViewModel()
            //    {
            //        Id = item.ProductId,
            //        TypeName = item.Name
            //    });
            //}

            //return new OkObjectResult(productViewModelList);

            return new OkObjectResult(new CustomBundleViewModel()
            {
                Id = customBundle.CustomBundleId,
                BundleId = customBundle.BundleId,
                Products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundle.CustomBundleId)
            });
        }

        public async Task<IActionResult> GetCustomBundleAsync(int bundleId)
        {
            //try
            //{
            CustomBundle customBundle = await _customBundlesRepository.GetCustomBundleAsync(bundleId);

            if (customBundle != null)
            {
                return new OkObjectResult(new CustomBundleViewModel()
                {
                    Id = customBundle.CustomBundleId,
                    BundleId = customBundle.BundleId,
                    Products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundle.CustomBundleId)
                });
            }
            else
            {
                return new NotFoundResult();
            }
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

        public Task<IActionResult> GetAllCustomBundlesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateCustomBundleAsync(int bundleId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PostRecommendedBundleAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> PostAddProductToBundleAsync(int customBundleId, string productName)
        {
            CustomBundle customBundle = await _customBundlesRepository.GetCustomBundleAsync(customBundleId);

            //Bundle bundle = await _bundlesRepository.GetBundleAsync(customBundle.BundleId);

            var products = await _bundlesRepository.GetBundleProductsAsync(customBundle.BundleId);

            //_productsRepository.
            

            var productType = await _productsRepository.GetProductTypeAsync(productName);

            if (productType.TypeName == "Account")
            {
                var accountProduct = products.Where(p => p.ProductTypeId == productType.Id).FirstOrDefault();

                if (accountProduct != null)
                    return new ForbidResult();
            }

            var sameProduct = products.Where(p => p.Name == productName).FirstOrDefault();

            if (sameProduct == null)
            {
                var product = await _productsRepository.GetProductAsync(productName);
                _customBundlesRepository.AddProductToCustomBundleAsync(customBundleId, product.ProductId);

                return await this.GetCustomBundleAsync(customBundleId);
            }

            return new ConflictResult();
        }
    }
}
