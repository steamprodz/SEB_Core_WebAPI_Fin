using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.ViewModels
{
    public class UpdateCustomBundleProductViewModel
    {
        public int CustomBundleId { get; set; }
        public string OldProductName { get; set; }
        public string NewProductName { get; set; }
    }
}
