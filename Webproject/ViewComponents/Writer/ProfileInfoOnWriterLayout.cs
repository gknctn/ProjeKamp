using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Webproject.ViewComponents.Writer
{
    public class ProfileInfoOnWriterLayout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var user = context.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            
            return View(user);
        }
    }
}
