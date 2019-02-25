using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Enums;
using SEB_Core_WebAPI.Extensions;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        //public async Task<IActionResult> FindProductsAsync(string sku)
        //{
        //    try
        //    {
        //        IEnumerable<Product> products = await _productsRepository.FindProductsAsync(sku);

        //        if (products != null)
        //        {
        //            return new OkObjectResult(products.Select(p => new ProductViewModel()
        //            {
        //                Id = p.ProductId,
        //                Sku = p.Sku.Trim(),
        //                Name = p.Name.Trim()
        //            }
        //            ));
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

        public async Task<IActionResult> GetAllProductsAsync()
        {
            //try
            //{
                IEnumerable<Product> products = await _productsRepository.GetAllProductsAsync();

                if (products != null)
                {
                    return new OkObjectResult(products.Select(p => new ProductViewModel()
                    {
                        Id = p.ProductId,
                        TypeName = p.Name //.ToEnum(),
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

        public async Task<IActionResult> GetProductAsync(int productId)
        {
            //try
            //{
                Product product = await _productsRepository.GetProductAsync(productId);

                if (product != null)
                {
                    return new OkObjectResult(new ProductViewModel()
                    {
                        Id = product.ProductId,
                        TypeName = product.Name //.ToEnum()
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

        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            //try
            //{
                Product product = await _productsRepository.DeleteProductAsync(productId);

                if (product != null)
                {
                    return new OkObjectResult(new ProductViewModel()
                    {
                        Id = product.ProductId,
                        TypeName = product.Name //.ToEnum()
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
