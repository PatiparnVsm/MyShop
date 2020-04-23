using MyShop.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace MyShop.Core.ViewModels
{
    public class ProductManagerListViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategory { get; set; }
    }
}
