using Microsoft.AspNetCore.Mvc;

namespace Webproject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
