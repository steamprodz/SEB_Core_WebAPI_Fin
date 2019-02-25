using Microsoft.EntityFrameworkCore;
using SEB_Core_WebAPI.Contexts;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly DefaultContext _context;

        public QuestionsRepository(DefaultContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int questionId)
        {
            return await _context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefaultAsync();
        }

        public async Task<Question> DeleteQuestionAsync(int questionId)
        {
            Question question = await GetQuestionAsync(questionId);

            if (question != null)
            {
                _context.Questions.Remove(question);

                await _context.SaveChangesAsync();
            }

            return question;
        }
    }
}
