using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webproject.Models;

namespace Webproject.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            WriterManager writermanager = new WriterManager(new EfWriterRepository());
            if (ModelState.IsValid)
            {
                Writer writer = new Writer();
                writer.WriterName = p.NameSurname;
                writer.WriterMail = p.Mail;
                writer.WriterStatus = true;
                writer.Writerpassword = p.Password;
                writermanager.TAdd(writer);
                AppUser user = new AppUser()
                {
                    UserName = p.UserName,
                    Email = p.Mail,
                    NameSurname = p.NameSurname
                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "LoginUser");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(p);
        }
    }
}
