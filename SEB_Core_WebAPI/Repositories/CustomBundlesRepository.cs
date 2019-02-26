using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Contexts;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Repositories
{
    public class CustomBundlesRepository : ICustomBundlesRepository
    {
        private readonly DefaultContext _context;

        public CustomBundlesRepository(DefaultContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Bundle>> GetAllCustomBundlesAsync()
        {
            return await _context.Bundles.ToListAsync();
        }

        public async Task<CustomBundle> GetCustomBundleAsync(int bundleId)
        {
            return await _context.CustomBundles.Where(b => b.BundleId == bundleId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetCustomBundleProductsAsync(int bundleId)
        {
            //Bundle bundle = await _context.Bundles.Where(b => b.BundleId == bundleId).FirstOrDefaultAsync();

            //List<Bundle_Product> bundleProducts = await _context.Bundle_Products.Where(bp => bp.Bundle_BundleId == bundleId).Join(_context.Products, (bp, p) => bp.Product)

            List<Product> products = new List<Product>();

            try
            {
                //var sss = _context.Bundle_Products.Where(bp => bp.Bundle_BundleId == bundleId).FirstOrDefault();

                var query =
                    from bundleProduct in _context.Bundle_Products
                    where bundleProduct.Bundle_BundleId == bundleId
                    join product in _context.Products on bundleProduct.Product_ProductId equals product.ProductId into gj
                    from subproduct in gj.DefaultIfEmpty()
                    select new { Id = subproduct.ProductId, Name = subproduct.Name };

                

                //foreach (var item in query)
                //{
                //    products.Add(new Product { ProductId = item.Id, Name = item.Name });
                //}

                await query.ForEachAsync(p => products.Add(new Product { ProductId = p.Id, Name = p.Name }));

            }
            catch (Exception ex)
            { }

            return products;

            //List<Product> products = new List<Product>();

            //foreach (var item in bundleProducts)
            //{
            //    products.Add(await _context.Products.Where(p => p.ProductId == item.Product_ProductId).ToListAsync());
            //}
        }

        public async Task<Bundle> FindCustomBundleAsync(string name)
        {
            return await _context.Bundles.Where(b => b.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Bundle> DeleteCustomBundleAsync(int bundleId)
        {
            Bundle bundle = await GetBundleAsync(bundleId);

            if (bundle != null)
            {
                _context.Bundles.Remove(bundle);

                await _context.SaveChangesAsync();
            }

            return bundle;
        }


        public async void AddProductToCustomBundleAsync(int customBundleId, int productId)
        {
            _context.Bundle_Products.Add(
                new Bundle_Product { Bundle_BundleId = customBundleId, Product_ProductId = productId });

            await _context.SaveChangesAsync();

            // return 
        }
    }
}
