using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IProductsService
    {
        Task<IActionResult> GetAllProductsAsync();
        Task<IActionResult> GetProductAsync(int productId);
        Task<IActionResult> DeleteProductAsync(int productId);
    }
}
