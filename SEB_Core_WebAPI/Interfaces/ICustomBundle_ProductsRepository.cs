using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundle_ProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int productId);
        //Task<IEnumerable<Product>> GetAvailableProductsAsync(int questionId);
        Task<Product> DeleteProductAsync(int productId);

        Task<Product> GetProductAsync(string productName);
        Task<ProductType> GetProductTypeAsync(string productName);
    }
}
