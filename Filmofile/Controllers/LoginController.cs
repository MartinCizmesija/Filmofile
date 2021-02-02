using Filmofile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Filmofile.Controllers
{
    public class LoginController : Controller
    {
        private readonly MovieDBContext context;
        private readonly AppSettings appData;

        public LoginController(MovieDBContext ctx, IOptionsSnapshot<AppSettings> options)
        {
            context = ctx;
            appData = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
