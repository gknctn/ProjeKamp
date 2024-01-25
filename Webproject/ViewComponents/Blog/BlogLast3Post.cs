using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Webproject.ViewComponents.Blog
{
	public class BlogLast3Post:ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLast3Blog();
			return View(values);
		}
	}
}
