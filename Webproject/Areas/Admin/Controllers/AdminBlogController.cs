using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webproject.Areas.Admin.Models;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        Context context = new Context();
        public IActionResult Index()
        {
            List<Blog> values = blogManager.GetBlogListWithCategoryAndWriter();
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            ViewBag.Id = id;
            BlogAndCommentModel blogAndCommentModel = new BlogAndCommentModel();
            var CommentValues = commentManager.GetListAll(id);
            var BlogValue = blogManager.TGetById(id);

            blogAndCommentModel.blog = BlogValue;
            blogAndCommentModel.comments = CommentValues;

            List<SelectListItem> categoryValues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogAndCommentModel);
        }

        [HttpPost]
        public IActionResult BlogEdit(BlogAndCommentModel p)
        {
            var userName = User.Identity.Name;
            var writerID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();

            p.blog.WriterID = writerID;
            p.blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blogManager.TUpdate(p.blog);
            return RedirectToAction("Index");
        }
    }
}
