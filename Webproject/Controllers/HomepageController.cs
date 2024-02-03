using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Webproject.Controllers
{
    [AllowAnonymous]
    public class HomepageController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            List<Blog> values = blogManager.GetBlogListWithCategoryAndWriter();
            return View(values);
        }
    }
}
