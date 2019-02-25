using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class Bundle_Product
    {
        //[Key, Column(Order = 0)]
        //[Key]
        public int Bundle_BundleId { get; set; }
        //[Key]
        public int Product_ProductId { get; set; }
    }
}
