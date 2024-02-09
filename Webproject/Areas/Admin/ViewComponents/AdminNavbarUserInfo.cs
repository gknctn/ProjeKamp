
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;

namespace Webproject.Areas.Admin.ViewComponents
{
    public class AdminNavbarUserInfo:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var value = context.Users.Where(x=>x.UserName== User.Identity.Name).FirstOrDefault();
            return View(value);
        }
    }
}
