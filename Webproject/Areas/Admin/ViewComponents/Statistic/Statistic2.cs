using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web.Mvc;

namespace Webproject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogID).Select(x => x.BlogName).Take(1).FirstOrDefault();
            return View();
        }
    }
}
