using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Webproject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(u => u.UserName == userName).Select(u => u.Email).FirstOrDefault();
            var userId = context.Writers.Where(u => u.WriterMail == userMail).Select(u => u.WriterID).FirstOrDefault();

            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == userId).Count();
            ViewBag.v3 = context.Categories.Count();

            return View();
        }
    }
}
