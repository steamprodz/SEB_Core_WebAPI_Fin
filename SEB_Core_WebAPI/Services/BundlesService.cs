using Microsoft.AspNetCore.Mvc;
using SEB_Core_WebAPI.Interfaces;
using SEB_Core_WebAPI.Models;
using SEB_Core_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Services
{
    public class BundlesService : IBundlesService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IBundlesRepository _bundlesRepository;


        public BundlesService(IBundlesRepository bundlesRepository, IQuestionsRepository questionsRepository, IProductsRepository productsRepository)
        {
            _bundlesRepository = bundlesRepository;
            _questionsRepository = questionsRepository;
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> GetAllBundlesAsync()
        {
            try
            {
                IEnumerable<Bundle> bundles = await _bundlesRepository.GetAllBundlesAsync();

                if (bundles != null)
                {
                    return new OkObjectResult(bundles.Select(b => new BundleViewModel()
                    {
                        Id = b.BundleId,
                        Name = b.Name,
                        Value = b.Value
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

        public async Task<IActionResult> GetBundleAsync(int bundleId)
        {
            try
            {
                Bundle bundle = await _bundlesRepository.GetBundleAsync(bundleId);

                if (bundle != null)
                {
                    return new OkObjectResult(new BundleViewModel()
                    {
                        Id = bundle.BundleId,
                        Name = bundle.Name,
                        Value = bundle.Value
                    });
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex)
            {
                return new ConflictResult();
            }
        }

        public async Task<IActionResult> DeleteBundleAsync(int bundleId)
        {
            try
            {
                Bundle bundle = await _bundlesRepository.DeleteBundleAsync(bundleId);

                if (bundle != null)
                {
                    return new OkObjectResult(new BundleViewModel()
                    {
                        Id = bundle.BundleId,
                        Name = bundle.Name,
                        Value = bundle.Value
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
