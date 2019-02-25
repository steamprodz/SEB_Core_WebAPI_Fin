using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class Bundle
    {
        public int BundleId { get; set; }
        //public Product.AccountType Account { get; set; }
        //public List<Product> ProductList { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
    }
}
