using BusinessLayer.Concrete;
using System;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Webproject.ViewComponents.Comment
{
    public class CommentListByBlog:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(Guid id)
        {
            var values = commentManager.GetListAll(id);
            return View(values);
        }
    }
}
