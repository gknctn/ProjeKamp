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
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.v3 = context.Categories.Count();

            return View();
        }
    }
}
