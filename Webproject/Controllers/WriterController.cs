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
        WriterManager writerManager = new WriterManager(new EfWriterRepository());

        Context context = new Context();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = User.Identity.Name;
            ViewBag.v = user;
            Context context = new Context();
            var writerName = context.Writers.Where(x => x.WriterMail == user).Select(y => y.WriterName).FirstOrDefault();
            var writerSurname = context.Writers.Where(x => x.WriterMail == user).Select(y => y.WriterSurname).FirstOrDefault();
            ViewBag.v2 = writerName;
            ViewBag.v3 = writerSurname;

            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            Context context = new Context();
            var userName = User.Identity.Name;
            var writerName = context.Writers.Where(x => x.WriterMail == userName).Select(y => y.WriterName).FirstOrDefault();
            var writerSurname = context.Writers.Where(x => x.WriterMail == userName).Select(y => y.WriterSurname).FirstOrDefault();

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
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.imageurl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserUpdateViewModel model)
        {
            //var id = context.Users.Where(x => x.UserName == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.NameSurname = model.namesurname;
            values.Email = model.mail;
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
            Writer writer = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                writer.WriterImage = newImageName;
            }
            writer.WriterName = p.WriterName;
            writer.WriterSurname = p.WriterSurname;
            writer.WriterStatus = true;
            writer.WriterMail = p.WriterMail;
            writer.WriterAbout = p.WriterAbout;
            writerManager.TAdd(writer);
            return RedirectToAction("Index", "Dashboard");
        }
        
    }
}
