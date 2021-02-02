using Filmofile.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Filmofile.Controllers
{
    public class DataController : Controller
    {

        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
    }
}