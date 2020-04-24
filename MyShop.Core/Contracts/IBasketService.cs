using System.Collections.Generic;
using System.Web;
using MyShop.Core.ViewModels;

namespace MyShop.Services
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpcontext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpcontext);
        void RemoveFromBasket(HttpContextBase httpContext, string productId);
        void IncreaseItemInBasket(HttpContextBase httpContext, string productId);
        void DecreaseItemInBasket(HttpContextBase httpContext, string productId);
    }
}