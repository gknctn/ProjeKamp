using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        void BlogRemove(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> GetAllBlogs();
        Blog GetBlog(Guid id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByWriter(Guid id);
	}
}
