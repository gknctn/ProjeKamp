using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webproject.Models;

namespace Webproject.Controllers
{
    public class WriterController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());

        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var writerName = context.Users.Where(x => x.UserName == userName).Select(y => y.Name).FirstOrDefault();
            var writerSurname = context.Users.Where(x => x.UserName == userName).Select(y => y.Surname).FirstOrDefault();

            SignedInUser SignedUser = new SignedInUser()
            {
                UserName = userName,
                Name = writerName,
                Surname = writerSurname
            };

            return PartialView(SignedUser);
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var values =await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.name = values.Name;
            model.surname = values.Surname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateViewModel model)
        {
            //var id = context.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.Name = model.name;
            values.Surname = model.surname;
            values.Email = model.mail;
            values.About = model.about;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            AppUser user= new AppUser();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                user.ImageUrl = newImageName;
            }
            user.Name= p.WriterName;
            user.Surname= p.WriterSurname;
            user.Status = true;
            user.Email= p.WriterMail;
            user.About= p.WriterAbout;
            userManager.TAdd(user);
            return RedirectToAction("Index", "Dashboard");
        }
        
    }
}
