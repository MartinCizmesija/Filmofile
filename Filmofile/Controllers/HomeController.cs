using Microsoft.AspNetCore.Mvc;

namespace Filmofile.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
