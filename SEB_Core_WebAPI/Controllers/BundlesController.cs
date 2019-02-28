using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;

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

        // POST api/bundles
        //[HttpPost]
        //public async Task<IActionResult> PostAddBundleAsync([FromBody]BundleViewModel bundleViewModel)
        //{
        //    return await _bundlesService.PostAddBundleAsync(bundleViewModel);
        //}

        //// POST api/bundles
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/bundles/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/bundles/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBundleAsync(int id)
        //{
        //    return await _bundlesService.DeleteBundleAsync(id);
        //}
    }
}
