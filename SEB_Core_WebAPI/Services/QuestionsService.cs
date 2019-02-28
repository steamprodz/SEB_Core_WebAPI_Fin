using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Extensions;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<IActionResult> GetAllQuestionsAsync()
        {
            try
            {
                IEnumerable<Question> questions = await _questionsRepository.GetAllQuestionsAsync();

                if (questions != null)
                {
                    return new OkObjectResult(questions.Select(q => new QuestionViewModel()
                    {
                        Id = q.QuestionId,
                        Age = q.Age,
                        IsStudent = q.IsStudent,
                        Income = q.Income
                    }
                    ));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> GetQuestionAsync(int questionId)
        {
            try
            {
                Question question = await _questionsRepository.GetQuestionAsync(questionId);

                if (question != null)
                {
                    return new OkObjectResult(new QuestionViewModel()
                    {
                        Id = question.QuestionId,
                        Age = question.Age,
                        IsStudent = question.IsStudent,
                        Income = question.Income
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> DeleteQuestionAsync(int questionId)
        {
            try
            {
                Question question = await _questionsRepository.DeleteQuestionAsync(questionId);

                if (question != null)
                {
                    return new OkObjectResult(new QuestionViewModel()
                    {
                        Id = question.QuestionId,
                        Age = question.Age,
                        IsStudent = question.IsStudent,
                        Income = question.Income
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }
        }
    }
}
