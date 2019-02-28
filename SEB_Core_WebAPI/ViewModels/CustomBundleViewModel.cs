using System.Collections.Generic;
using SEB_Core_WebAPI.Enums;
using SEB_Core_WebAPI.Models;

namespace SEB_Core_WebAPI.ViewModels
{
    public class CustomBundleViewModel
    {
        public long Id { get; set; }
        public long DefaultBundleId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        //public long QuestionId
    }
}
