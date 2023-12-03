using Microsoft.AspNetCore.Mvc;

namespace Webproject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
