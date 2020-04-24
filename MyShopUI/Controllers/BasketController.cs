using MyShop.Services;
using System.Web.Mvc;

namespace MyShopUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;

        public BasketController(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            //var m = new MyShop.Core.ViewModels.BasketItemViewModel
            //{
            //    Price = 12,
            //    ProductName = "test"
            //};
            //model.Add(m);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary(string Id)
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }

}