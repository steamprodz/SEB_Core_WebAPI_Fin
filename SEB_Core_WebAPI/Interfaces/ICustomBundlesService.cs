using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Models;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundlesService
    {
        Task<IActionResult> GetAllCustomBundlesAsync();
        Task<IActionResult> GetCustomBundleAsync(int bundleId);
        Task<IActionResult> UpdateCustomBundleAsync(int bundleId);
        Task<IActionResult> DeleteBundleAsync(int bundleId);

        Task<IActionResult> PostRecommendedBundleAsync(Question question);

        Task<IActionResult> PostAddProductToBundleAsync(int customBundleId, string productName);
    }
}
