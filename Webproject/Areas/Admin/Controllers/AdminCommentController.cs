using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Webproject.Areas.Admin.Models;
using X.PagedList;

namespace Webproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        public IActionResult Index(int page = 1)
        {
            var values = _commentManager.GetCommentListWithBlog().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult CommentEdit(int id)
        {
            BlogAndCommentModel blogAndCommentModel = new BlogAndCommentModel();
            blogAndCommentModel.comment = _commentManager.TGetById(id);
            return View(blogAndCommentModel);
        }
        [HttpPost]
        public IActionResult CommentEdit(BlogAndCommentModel p)
        {
            _commentManager.TUpdate(p.comment);
            return RedirectToAction("Index");
        }
    }
}
