using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Webproject.ViewComponents.Writer
{
    public class ProfileInfoOnMainLayout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();

            return View(user);
        }
    }
}
