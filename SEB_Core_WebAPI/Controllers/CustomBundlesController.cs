using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEB_Core_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBundlesController : Controller
    {
        private readonly ICustomBundlesService _customBundlesService;

        public CustomBundlesController(ICustomBundlesService customBundlesService)
        {
            _customBundlesService = customBundlesService;
        }

        // GET: api/custombundles
        [HttpGet]
        public async Task<IActionResult> GetAllCustomBundlesAsync()
        {
            return await _customBundlesService.GetAllCustomBundlesAsync();
        }

        // GET api/custombundles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomBundleAsync(int id)
        {
            return await _customBundlesService.GetCustomBundleAsync(id);
        }

        // Post api/custombundles/addproduct
        [HttpPost("addproduct")]
        public async Task<IActionResult> PostAddProductToBundleAsync([FromBody]int customBundleId, string productName)
        {
            return await _customBundlesService.PostAddProductToBundleAsync(customBundleId, productName);
        }



        //// POST api/bundles
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/bundles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bundles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBundleAsync(int id)
        {
            return await _customBundlesService.DeleteBundleAsync(id);
        }
    }
}
