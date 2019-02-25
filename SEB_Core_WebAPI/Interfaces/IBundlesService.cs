using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IBundlesService
    {
        Task<IActionResult> GetAllBundlesAsync();
        Task<IActionResult> GetBundleAsync(int bundleId);
        Task<IActionResult> GetRecommendedBundleAsync(int questionId);
        Task<IActionResult> DeleteBundleAsync(int bundleId);
    }
}
