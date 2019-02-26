using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundlesRepository
    {
        Task<IEnumerable<Bundle>> GetAllCustomBundlesAsync();
        Task<CustomBundle> GetCustomBundleAsync(int bundleId);
        Task<Bundle> FindCustomBundleAsync(string name);
        Task<Bundle> DeleteCustomBundleAsync(int bundleId);

        Task<IEnumerable<Product>> GetCustomBundleProductsAsync(int bundleId);

        void AddProductToCustomBundleAsync(int customBundleId, int productId);
    }
}
