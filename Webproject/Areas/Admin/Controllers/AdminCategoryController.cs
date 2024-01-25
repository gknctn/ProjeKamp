using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using X.PagedList;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
        public IActionResult Index(int page = 1)
        {
            var values = categoryManager.TGetList().ToPagedList(page,5);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);

            if (validationResult.IsValid)
            {
                p.CategoryStatus = true;
                categoryManager.TAdd(p);

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult PassiveCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            values.CategoryStatus = false;
            categoryManager.TUpdate(values);
            return RedirectToAction("Index");
        }
        public IActionResult ActiveCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            values.CategoryStatus = true;
            categoryManager.TUpdate(values);

            return RedirectToAction("Index");
        }
    }
}
