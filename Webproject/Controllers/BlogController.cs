using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Webproject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Blog> values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            ViewBag.CommentCount = context.Comments.Where(x=>x.BlogID==id).Select(y=>y.CommentId).Count();
            var CategoryID = context.Blogs.Where(x=>x.BlogID==id).Select(y=>y.CategoryID).FirstOrDefault();
            ViewBag.CategoryName=context.Categories.Where(x=>x.CategoryID== CategoryID).Select(y=>y.CategoryName).FirstOrDefault();
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var userName = User.Identity.Name;
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            var values = blogManager.GetListWithCategoryByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult validationResult = blogValidator.Validate(p);

            var userName = User.Identity.Name;
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            if (validationResult.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                blogManager.TAdd(p);

                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            blogManager.TDelete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = blogManager.TGetById(id);
            List<SelectListItem> categoryValues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(value);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var userName = User.Identity.Name;
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            blogManager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
