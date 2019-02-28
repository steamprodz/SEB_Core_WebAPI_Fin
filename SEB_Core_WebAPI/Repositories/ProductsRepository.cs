using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Contexts;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DefaultContext _context;

        public ProductsRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductAsync(string productName)
        {
            return await _context.Products.Where(p => p.Name == productName).FirstOrDefaultAsync();
        }

        public async Task<ProductType> GetProductTypeAsync(int productId)
        {
            var product = await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

            return await _context.ProductTypes.Where(pt => pt.Id == product.ProductTypeId).FirstOrDefaultAsync();
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            Product product = await GetProductAsync(productId);

            if (product != null)
            {
                _context.Products.Remove(product);

                await _context.SaveChangesAsync();
            }

            return product;
        }
    }
}
