using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;
		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}
		public void BlogAdd(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogRemove(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogUpdate(Blog blog)
		{
			throw new NotImplementedException();
		}
		public List<Blog> GetBlogByID(Guid id)
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> GetAllBlogs()
		{
			return _blogDal.GetListAll();
		}

		public Blog GetBlog(Guid id)
		{
			return _blogDal.getById(id);
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetWithCategory();
		}

		public List<Blog> GetBlogListByWriter(Guid id)
		{
			return _blogDal.GetListAll(x=>x.WriterID==id) ;

		}
	}
}
