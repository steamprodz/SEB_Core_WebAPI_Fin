using System.Collections.Generic;
using SEB_Core_WebAPI.Enums;
using SEB_Core_WebAPI.Models;

namespace SEB_Core_WebAPI.ViewModels
{
    public class CustomBundleViewModel
    {
        public long Id { get; set; }
        public long BundleId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        //public long QuestionId
    }
}
