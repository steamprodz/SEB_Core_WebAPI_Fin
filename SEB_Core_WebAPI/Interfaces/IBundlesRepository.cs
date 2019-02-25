using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IBundlesRepository
    {
        Task<IEnumerable<Bundle>> GetAllBundlesAsync();
        Task<Bundle> GetBundleAsync(int BundleId);
        //Task<Bundle> GetRecommendedBundleAsync(int questionId);
        Task<Bundle> DeleteBundleAsync(int BundleId);
    }
}
