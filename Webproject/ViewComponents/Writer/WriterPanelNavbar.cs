using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Webproject.ViewComponents.Writer
{
    public class WriterPanelNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            //var userId = context.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            return View(user);
        }
    }
}
