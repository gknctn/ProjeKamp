using Microsoft.AspNetCore.Mvc;

namespace Webproject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
