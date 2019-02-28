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


        public CustomBundlesService(ICustomBundlesRepository customBundlesRepository, IBundlesRepository bundlesRepository, IQuestionsRepository questionsRepository, IProductsRepository productsRepository)
        {
            _customBundlesRepository = customBundlesRepository;
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

        //public async Task<IActionResult> PostRecommendedCustomBundleAsync(Question question)
        //{
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

        //    //var products = await _bundlesRepository.GetBundleProductsAsync(bundle.BundleId);

        //    //List<ProductViewModel> productViewModelList = new List<ProductViewModel>();

        //    //foreach (var item in products)
        //    //{
        //    //    productViewModelList.Add(new ProductViewModel()
        //    //    {
        //    //        Id = item.ProductId,
        //    //        TypeName = item.Name
        //    //    });
        //    //}

        //    //return new OkObjectResult(productViewModelList);

        //    return new OkObjectResult(new CustomBundleViewModel()
        //    {
        //        Id = customBundle.CustomBundleId,
        //        BundleId = customBundle.BundleId,
        //        Products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundle.CustomBundleId)
        //    });
        //}

        public async Task<IActionResult> GetCustomBundleAsync(int bundleId)
        {
            //try
            //{
            CustomBundle customBundle = await _customBundlesRepository.GetCustomBundleAsync(bundleId);

            var products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundle.CustomBundleId);

            if (customBundle != null)
            {
                return new OkObjectResult(new CustomBundleViewModel()
                {
                    Id = customBundle.CustomBundleId,
                    DefaultBundleId = customBundle.BundleId,
                    Products = this.ProductsToViewModels(products)
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

        public async Task<IActionResult> PostRecommendedBundleAsync(QuestionViewModel qvm)
        {
            try
            {
                //CustomBundle cb;
                //IEnumerable<Product> products;
                //List<ProductViewModel> pvmList;
                //Question q = await _questionsRepository.GetQuestionAsync(qvm.Age, qvm.IsStudent, qvm.Income);

                //if (q != null)
                //{
                //    cb = await _customBundlesRepository.FindCustomBundleAsync(q.QuestionId);

                //    if (cb != null)
                //    {
                //        products = await _customBundlesRepository.GetCustomBundleProductsAsync(cb.CustomBundleId);

                //        pvmList = new List<ProductViewModel>();

                //        foreach (var p in products)
                //        {
                //            pvmList.Add(new ProductViewModel { Id = p.ProductId, Name = p.Name });
                //        }

                //        return new OkObjectResult(new CustomBundleViewModel()
                //        {
                //            Id = cb.CustomBundleId,
                //            DefaultBundleId = cb.BundleId,
                //            Products = pvmList
                //        });
                //    }
                //}

                // Create question
                //if (q == null)
                Question q = await _questionsRepository.AddQuestionAsync(qvm.Age, qvm.IsStudent, qvm.Income);

                // Find default bundle
                var defaultBundle = await this.FindDefaultBundleAsync(q);
                // Create custom bundle
                var cb = await this.AddCustomBundleAsync(q.QuestionId, defaultBundle.BundleId);
                // Get products
                var products = await _bundlesRepository.GetBundleProductsAsync(defaultBundle.BundleId);

                return new OkObjectResult(new CustomBundleViewModel()
                {
                    Id = cb.CustomBundleId,
                    DefaultBundleId = cb.BundleId,
                    Products = this.ProductsToViewModels(products)
                });
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }

        private IEnumerable<ProductViewModel> ProductsToViewModels(IEnumerable<Product> products)
        {
            var pvmList = new List<ProductViewModel>();

            foreach (var p in products)
            {
                pvmList.Add(new ProductViewModel { Id = p.ProductId, Name = p.Name });
            }

            return pvmList;
        }

        public async Task<CustomBundle> AddCustomBundleAsync(int questionId, int defaultBundleId)
        {
            // Create new CB
            var cb = await _customBundlesRepository.AddCustomBundleAsync(questionId, defaultBundleId);

            // Get default products
            var products = await _bundlesRepository.GetBundleProductsAsync(defaultBundleId);

            // Copy products to CB
            foreach (var p in products)
            {
                await _customBundlesRepository.AddProductToCustomBundleAsync(cb.CustomBundleId, p.ProductId);
            }

            return cb;
        }

        public async Task<Bundle> FindDefaultBundleAsync(Question q)
        {
            //Bundle bundle = null;

            if (q.Income > 40000 && q.Age > 17)
            {
                return await _bundlesRepository.FindBundleAsync("Gold");
            }
            else if (q.Income > 12000 && q.Age > 17)
            {
                return await _bundlesRepository.FindBundleAsync("Classic Plus");
            }
            else if (q.Age > 17 && q.Income > 0)
            {
                return await _bundlesRepository.FindBundleAsync("Classic");
            }
            else if (q.Age > 17 && q.IsStudent)
            {
                return await _bundlesRepository.FindBundleAsync("Student");
            }
            else if (q.Age < 18)
            {
                return await _bundlesRepository.FindBundleAsync("Junior Saver");
            }

            return await _bundlesRepository.FindBundleAsync("Junior Saver");
        }

        public async Task<IActionResult> FindDefaultBundle(QuestionViewModel qvm)
        {
            Bundle bundle = null;

            if (qvm.Income > 40000 && qvm.Age > 17)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Gold");
            }
            else if (qvm.Income > 12000 && qvm.Age > 17)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Classic Plus");
            }
            else if (qvm.Age > 17 && qvm.Income > 0)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Classic");
            }
            else if (qvm.Age > 17 && qvm.IsStudent)
            {
                bundle = await _bundlesRepository.FindBundleAsync("Student");
            }
            else if (qvm.Age < 18)
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

        public async Task<IActionResult> PostAddProductToBundleAsync(int customBundleId, string productName)
        {
            var cb = await _customBundlesRepository.GetCustomBundleAsync(customBundleId);
            var q = await _questionsRepository.GetQuestionAsync(cb.QuestionId);
            var p = await _productsRepository.GetProductAsync(productName);
            var products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundleId);

            // Check if such product is already in bundle
            var sameProduct = products.Where(pp => pp.ProductId == p.ProductId);
            if (sameProduct != null)
                return new BadRequestResult();

            // Check if there no more than 1 Account product
            var pt = await _productsRepository.GetProductTypeAsync(p.ProductId);

            if (pt.TypeName == "Account")
            {
                var productAcc = products.Where(pp => pp.ProductTypeId == pt.Id).FirstOrDefault();

                if (productAcc != null)
                    return new BadRequestResult();
            }

            int accCount = products.Count(pp => pp.ProductTypeId == pt.Id);
            bool checkIfAccPresent = false;

            switch (p.Name)
            {
                case "Current Account":
                    if (q.Income <= 0 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Current Account Plus":
                    if (q.Income <= 40000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Junior Saver Account":
                    if (q.Age >= 18)
                        return new BadRequestResult();
                    break;
                case "Student Account":
                    if (!q.IsStudent || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Debit Card":
                    checkIfAccPresent = true;
                    break;
                case "Credit Card":
                    if (q.Income <= 12000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Gold Credit Card":
                    if (q.Income <= 40000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
            }

            if (checkIfAccPresent && accCount == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        private async Task<IActionResult> ValidateNewProduct(IEnumerable<Product> products, Question question, Product newProduct)
        {
            // Check if such product is already in bundle
            var sameProduct = products.Where(pp => pp.ProductId == newProduct.ProductId);
            if (sameProduct != null)
                return new BadRequestResult();

            // Check if there no more than 1 Account product
            var pt = await _productsRepository.GetProductTypeAsync(newProduct.ProductId);

            if (pt.TypeName == "Account")
            {
                var productAcc = products.Where(pp => pp.ProductTypeId == pt.Id).FirstOrDefault();

                if (productAcc != null)
                    return new BadRequestResult();
            }

            int accCount = products.Count(pp => pp.ProductTypeId == pt.Id);
            bool checkIfAccPresent = false;

            switch (newProduct.Name)
            {
                case "Current Account":
                    if (question.Income <= 0 || question.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Current Account Plus":
                    if (question.Income <= 40000 || question.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Junior Saver Account":
                    if (question.Age >= 18)
                        return new BadRequestResult();
                    break;
                case "Student Account":
                    if (!question.IsStudent || question.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Debit Card":
                    checkIfAccPresent = true;
                    break;
                case "Credit Card":
                    if (question.Income <= 12000 || question.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Gold Credit Card":
                    if (question.Income <= 40000 || question.Age <= 17)
                        return new BadRequestResult();
                    break;
            }

            if (checkIfAccPresent && accCount == 0)
                return new BadRequestResult();

            return new OkResult();
        }

        public async Task<IActionResult> PutUpdateProductInCustomBundleAsync(int customBundleId, string oldProductName, string newProductName)
        {
            var cb = await _customBundlesRepository.GetCustomBundleAsync(customBundleId);
            var q = await _questionsRepository.GetQuestionAsync(cb.QuestionId);
            var products = await _customBundlesRepository.GetCustomBundleProductsAsync(customBundleId);

            var oldProduct = products.Where(pp => pp.Name == oldProductName).FirstOrDefault();
            var newProduct = products.Where(pp => pp.Name == newProductName).FirstOrDefault();

            // Check if there no more than 1 Account product
            var pt = await _productsRepository.GetProductTypeAsync(newProduct.ProductId);

            if (pt.TypeName == "Account")
            {
                var productAcc = products.Where(pp => pp.ProductTypeId == pt.Id).FirstOrDefault();

                if (productAcc != null)
                    return new BadRequestResult();
            }

            int accCount = products.Count(pp => pp.ProductTypeId == pt.Id);
            bool checkIfAccPresent = false;

            switch (newProduct.Name)
            {
                case "Current Account":
                    if (q.Income <= 0 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Current Account Plus":
                    if (q.Income <= 40000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Junior Saver Account":
                    if (q.Age >= 18)
                        return new BadRequestResult();
                    break;
                case "Student Account":
                    if (!q.IsStudent || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Debit Card":
                    checkIfAccPresent = true;
                    break;
                case "Credit Card":
                    if (q.Income <= 12000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
                case "Gold Credit Card":
                    if (q.Income <= 40000 || q.Age <= 17)
                        return new BadRequestResult();
                    break;
            }

            if (checkIfAccPresent && accCount == 0)
                return new BadRequestResult();

            await _customBundlesRepository.UpdateProductInCustomBundleAsync(customBundleId, oldProduct.ProductId, newProduct.ProductId);

            return new OkResult();
        }

        public async Task<IActionResult> DeleteProductInCustomBundleAsync(int customBundleId, string productName)
        {
            var p = await _productsRepository.GetProductAsync(productName);

            await _customBundlesRepository.DeleteProductInCustomBundleAsync(customBundleId, p.ProductId);

            return new OkResult();
        }

        public async Task<IActionResult> PostValidateCustomBundle(CustomBundleViewModel cbvm, QuestionViewModel qvm)
        {
            //var cb = await this.GetCustomBundleAsync(cbvm.Id);
            //var products = await _customBundlesRepository.GetCustomBundleProductsAsync(cbvm.Id);

            var products = cbvm.Products;

            int accountCount = 0;
            bool checkIfAccPresent = false;

            foreach (var p in products)
            {
                switch (p.Name)
                {
                    case "Current Account":
                        if (qvm.Income <= 0 || qvm.Age <= 17)
                            return new BadRequestResult();
                        accountCount++;
                        break;
                    case "Current Account Plus":
                        if (qvm.Income <= 40000 || qvm.Age <= 17)
                            return new BadRequestResult();
                        accountCount++;
                        break;
                    case "Junior Saver Account":
                        if (qvm.Age >= 18)
                            return new BadRequestResult();
                        accountCount++;
                        break;
                    case "Student Account":
                        if (!qvm.IsStudent || qvm.Age <= 17)
                            return new BadRequestResult();
                        accountCount++;
                        break;
                    case "Debit Card":
                        checkIfAccPresent = true;
                        break;
                    case "Credit Card":
                        if (qvm.Income <= 12000 || qvm.Age <= 17)
                            return new BadRequestResult();
                        break;
                    case "Gold Credit Card":
                        if (qvm.Income <= 40000 || qvm.Age <= 17)
                            return new BadRequestResult();
                        break;
                }
            }

            if (accountCount > 1)
                return new BadRequestResult();
            else if (checkIfAccPresent && accountCount == 0)
                return new BadRequestResult();

            return new OkResult();
        }
    }
}
