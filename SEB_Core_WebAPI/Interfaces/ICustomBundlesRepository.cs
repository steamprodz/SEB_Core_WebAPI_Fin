using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundlesRepository
    {
        Task<IEnumerable<CustomBundle>> GetAllCustomBundlesAsync();
        Task<CustomBundle> GetCustomBundleAsync(int bundleId);
        Task<CustomBundle> DeleteCustomBundleAsync(int bundleId);
        Task<IEnumerable<Product>> GetCustomBundleProductsAsync(int bundleId);

        Task<CustomBundle> FindCustomBundleAsync(int questionId);

        Task<CustomBundle> AddCustomBundleAsync(int questionId, int defaultBundleId);
        Task<CustomBundle_Product> AddProductToCustomBundleAsync(int customBundleId, int productId);
        Task<CustomBundle_Product> UpdateProductInCustomBundleAsync(int customBundleId, int oldProductId, int newProductId);
        Task DeleteProductInCustomBundleAsync(int customBundleId, int productId);
    }
}
