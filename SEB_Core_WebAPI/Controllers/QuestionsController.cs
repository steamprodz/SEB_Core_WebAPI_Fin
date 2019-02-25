using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEB_Core_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<IActionResult> GetAllQuestionsAsync()
        {
            return await _questionsService.GetAllQuestionsAsync();
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionAsync(int id)
        {
            return await _questionsService.GetQuestionAsync(id);
        }

        // POST api/questions
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/questions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAsync(int id)
        {
            return await _questionsService.DeleteQuestionAsync(id);
        }
    }
}
