using BookStore.Mvc.Extensions;
using BookStore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Mvc.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var courseCollection = HttpContext.Session.GetJson<BookCollection>("basket");
            return View(courseCollection);
        }
    }
}
