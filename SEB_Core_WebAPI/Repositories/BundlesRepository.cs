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
    public class BundlesRepository : IBundlesRepository
    {
        private readonly DefaultContext _context;

        public BundlesRepository(DefaultContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Bundle>> GetAllBundlesAsync()
        {
            return await _context.Bundles.ToListAsync();
        }

        public async Task<Bundle> GetBundleAsync(int bundleId)
        {
            return await _context.Bundles.Where(b => b.BundleId == bundleId).FirstOrDefaultAsync();
        }

        public async Task<Bundle> DeleteBundleAsync(int bundleId)
        {
            Bundle bundle = await GetBundleAsync(bundleId);

            if (bundle != null)
            {
                _context.Bundles.Remove(bundle);

                await _context.SaveChangesAsync();
            }

            return bundle;
        }

        //public async Task<Bundle> GetRecommendedBundleAsync(int questionId)
        //{
        //    List<Product> productList = new List<Product>();

        //    Question question = await _context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefaultAsync();

        //    ///// Some logic
        //    if (question.Age == 0)
        //        productList.AddRange(new Product[] { new Product { ProductType = Product.AccountCardType.CreditCard }, new Product { ProductType = Product.AccountCardType.CurrentAccount } });


        //    return new Bundle { ProductList = productList };
        //    /////
        //}
    }
}
