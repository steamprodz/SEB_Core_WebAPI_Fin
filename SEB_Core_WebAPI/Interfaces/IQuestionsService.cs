using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IQuestionsService
    {
        Task<IActionResult> GetAllQuestionsAsync();
        Task<IActionResult> GetQuestionAsync(int questionId);
        Task<IActionResult> DeleteQuestionAsync(int questionId);
    }
}
