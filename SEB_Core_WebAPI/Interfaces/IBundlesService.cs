using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Models;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IBundlesService
    {
        Task<IActionResult> GetAllBundlesAsync();
        Task<IActionResult> GetBundleAsync(int bundleId);
        Task<IActionResult> DeleteBundleAsync(int bundleId);
    }
}
