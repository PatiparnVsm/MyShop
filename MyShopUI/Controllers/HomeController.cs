using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.DataAccess.SQL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyShopUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public HomeController(SQLRepository<Product> productContext, SQLRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        public ActionResult Index(string Category = null)
        {
            //List<Product> products = context.Collection().ToList();

            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if(Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(cat => cat.Category == Category).ToList();
            }

            ProductManagerListViewModel listViewModel = new ProductManagerListViewModel();
            listViewModel.Product = products;
            listViewModel.ProductCategory = categories;
            return View(listViewModel);
        }

        public ActionResult Detail(string Id)
        {
            Product productDetail = context.Find(Id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            else
            {
                return RedirectToAction("ProductDetail", new { id = Id });
            }
        }

        public ActionResult ProductDetail(string Id)
        {
            Product productDetail = context.Find(Id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productDetail);
            }
        }
    }
}