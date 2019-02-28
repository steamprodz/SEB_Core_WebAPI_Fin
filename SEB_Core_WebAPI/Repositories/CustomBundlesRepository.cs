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

        public async Task<IEnumerable<CustomBundle>> GetAllCustomBundlesAsync()
        {
            return await _context.CustomBundles.ToListAsync();
        }

        public async Task<CustomBundle> GetCustomBundleAsync(int customBundleId)
        {
            return await _context.CustomBundles.Where(b => b.CustomBundleId == customBundleId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetCustomBundleProductsAsync(int customBundleId)
        {
            List<Product> products = new List<Product>();

            try
            {
                var query =
                    from customBundle_Products in _context.CustomBundle_Products
                    where customBundle_Products.CustomBundleId == customBundleId
                    join product in _context.Products on customBundle_Products.ProductId equals product.ProductId into gj
                    from subproduct in gj.DefaultIfEmpty()
                    select new { Id = subproduct.ProductId, Name = subproduct.Name };

                await query.ForEachAsync(p => products.Add(new Product { ProductId = p.Id, Name = p.Name }));

            }
            catch (Exception ex)
            { }

            return products;
        }

        public async Task<CustomBundle> DeleteCustomBundleAsync(int bundleId)
        {
            var cb = await this.GetCustomBundleAsync(bundleId);

            if (cb != null)
            {
                _context.CustomBundles.Remove(cb);
                await _context.SaveChangesAsync();
            }

            return cb;
        }
        

        public async Task<CustomBundle> FindCustomBundle(Question question)
        {
            CustomBundle customBundle = null;

            var q = await _context.Questions.Where(qq => qq.Age == question.Age && qq.IsStudent == question.IsStudent && qq.Income == question.Income).FirstOrDefaultAsync();

            if (q != null)
            {
                customBundle = await _context.CustomBundles.Where(cb => cb.QuestionId == q.QuestionId).FirstOrDefaultAsync();
            }

            return customBundle;
        }

        public async Task<CustomBundle> FindCustomBundleAsync(int questionId)
        {
            return await _context.CustomBundles.Where(cb => cb.QuestionId == questionId).FirstOrDefaultAsync();
        }

        public async Task<CustomBundle> AddCustomBundleAsync(int questionId, int defaultBundleId)
        {
            var cb = await _context.CustomBundles.AddAsync(new CustomBundle { BundleId = defaultBundleId, QuestionId = questionId });
            await _context.SaveChangesAsync();

            return cb.Entity;
        }

        public async Task<CustomBundle_Product> AddProductToCustomBundleAsync(int customBundleId, int productId)
        {
            var cb_p = await _context.CustomBundle_Products.AddAsync(new CustomBundle_Product { CustomBundleId = customBundleId, ProductId = productId });
            await _context.SaveChangesAsync();

            return cb_p.Entity;
        }

        public async Task<CustomBundle_Product> UpdateProductInCustomBundleAsync(int customBundleId, int oldProductId, int newProductId)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<CustomBundle_Product> cb_p = null;

            var cb_product = await _context.CustomBundle_Products.Where(cbp => cbp.CustomBundleId == customBundleId && cbp.ProductId == oldProductId).FirstOrDefaultAsync();

            if (cb_product != null)
            {
                cb_p = _context.CustomBundle_Products.Update(cb_product);

                cb_p.Entity.ProductId = newProductId;

                await _context.SaveChangesAsync();
            }

            return cb_p.Entity;
        }

        public async Task DeleteProductInCustomBundleAsync(int customBundleId, int productId)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<CustomBundle_Product> cb_p = null;

            var cb_product = await _context.CustomBundle_Products.Where(cbp => cbp.CustomBundleId == customBundleId && cbp.ProductId == productId).FirstOrDefaultAsync();

            if (cb_product != null)
            {
                cb_p = _context.CustomBundle_Products.Remove(cb_product);

                await _context.SaveChangesAsync();
            }
        }
    }
}
