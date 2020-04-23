using MyShop.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace MyShop.Core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
    }
}
