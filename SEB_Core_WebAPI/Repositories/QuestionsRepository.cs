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


        // Get question by Id
        public async Task<Question> GetQuestionAsync(int questionId)
        {
            return await _context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefaultAsync();
        }

        // Get question by params
        public async Task<Question> GetQuestionAsync(int age, bool isStudent, long income)
        {
            return await _context.Questions.Where(q => q.Age == age && q.IsStudent == isStudent && q.Income == income).FirstOrDefaultAsync();
        }

        // Create new record
        public async Task<Question> AddQuestionAsync(int age, bool isStudent, long income)
        {
            var q = await _context.Questions.AddAsync(new Question { Age = age, IsStudent = isStudent, Income = income });
            await _context.SaveChangesAsync();

            return q.Entity;
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
