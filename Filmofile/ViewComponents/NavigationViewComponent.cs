using Microsoft.AspNetCore.Mvc;

namespace Filmofile.ViewComponents
{
    public class NavigationViewComponent : ViewComponent {

        public IViewComponentResult Invoke()
        {
            ViewBag.Controller = RouteData?.Values["Controller"];
            return View();
        }

    }
}
