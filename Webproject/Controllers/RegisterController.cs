using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Webproject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
         
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator writerValidator =new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(p);
            if (validationResult.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Bu deneme içeriğidir";
                writerManager.WriterAdd(p);

                return RedirectToAction("index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
            
        }
    }
}
