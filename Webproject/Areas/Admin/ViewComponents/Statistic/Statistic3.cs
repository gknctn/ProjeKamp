using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Webproject.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.TotalUser = context.Users.Count();
            ViewBag.v1 = context.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogName).Take(1).FirstOrDefault();
            return View();
        }
    }
}
