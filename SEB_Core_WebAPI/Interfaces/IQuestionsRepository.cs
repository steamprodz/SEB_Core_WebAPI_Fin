using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionAsync(int questionId);
        Task<Question> DeleteQuestionAsync(int questionId);
    }
}
