﻿using SEB_Core_WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Interfaces
{
    public interface ICustomBundlesRepository
    {
        Task<IEnumerable<Bundle>> GetAllCustomBundlesAsync();
        Task<CustomBundle> GetCustomBundleAsync(int bundleId);
        //Task<Bundle> FindCustomBundleAsync(string name);
        Task<CustomBundle> DeleteCustomBundleAsync(int bundleId);

        Task<IEnumerable<Product>> GetCustomBundleProductsAsync(int bundleId);

        Task<CustomBundle> FindCustomBundleAsync(int questionId);

        Task<CustomBundle> AddCustomBundleAsync(int questionId, int defaultBundleId);
        Task<CustomBundle_Product> AddProductToCustomBundleAsync(int customBundleId, int productId);
    }
}
