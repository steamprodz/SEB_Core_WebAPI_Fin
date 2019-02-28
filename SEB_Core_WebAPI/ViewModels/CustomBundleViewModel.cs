using System.Collections.Generic;
using SEB_Core_WebAPI.Enums;
using SEB_Core_WebAPI.Models;

namespace SEB_Core_WebAPI.ViewModels
{
    public class CustomBundleViewModel
    {
        public int Id { get; set; }
        public int DefaultBundleId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        //public long QuestionId
    }
}
