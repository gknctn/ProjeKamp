using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Webproject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            
            var values = userManager.GetWriterById(userID);
            return View(values);
        }
    }
}
