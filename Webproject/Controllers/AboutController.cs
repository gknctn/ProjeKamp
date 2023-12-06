using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Webproject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = aboutManager.GetListAll();
            return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        }
    }
}
