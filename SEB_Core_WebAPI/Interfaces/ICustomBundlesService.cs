using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundlesService
    {
        Task<IActionResult> GetAllCustomBundlesAsync();
        Task<IActionResult> GetCustomBundleAsync(int bundleId);
        Task<IActionResult> UpdateCustomBundleAsync(int bundleId);
        Task<IActionResult> DeleteBundleAsync(int bundleId);

        Task<IActionResult> PostRecommendedBundleAsync(QuestionViewModel qvm);

        Task<IActionResult> PostAddProductToBundleAsync(int customBundleId, string productName);

        Task<Bundle> FindDefaultBundleAsync(Question q);
        Task<CustomBundle> AddCustomBundleAsync(int questionId, int defaultBundleId);
        Task<IActionResult> PostValidateCustomBundle(CustomBundleViewModel cbvm, QuestionViewModel qvm);
    }
}
