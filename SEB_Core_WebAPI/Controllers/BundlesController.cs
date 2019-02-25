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
    public class BundlesController : Controller
    {
        private readonly IBundlesService _bundlesService;

        public BundlesController(IBundlesService bundlesService)
        {
            _bundlesService = bundlesService;
        }

        // GET: api/bundles
        [HttpGet]
        public async Task<IActionResult> GetAllBundlesAsync()
        {
            return await _bundlesService.GetAllBundlesAsync();
        }

        // GET api/bundles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBundleAsync(int id)
        {
            return await _bundlesService.GetBundleAsync(id);
        }

        // GET api/bundles/recommended/5
        [HttpGet("recommended/{questionId}")]
        public async Task<IActionResult> GetRecommendedBundleAsync(int questionId)
        {
            return await _bundlesService.GetRecommendedBundleAsync(questionId);
        }

        // POST api/bundles
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/bundles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bundles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBundleAsync(int id)
        {
            return await _bundlesService.DeleteBundleAsync(id);
        }
    }
}
