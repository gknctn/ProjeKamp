using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Webproject.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager blogManager=new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			
			//var values = blogManager.GetBlogListByWriter("");
			var values = blogManager.GetAllBlogs();
			return View(values);
		}
	}
}
