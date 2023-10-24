using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    internal class BlogRepository : IBlogDal
    {
        Context context = new Context();

        public void RemoveBlog(Blog blog)
        {
            context.Remove(blog);
            context.SaveChanges();
        }

        public void BlogAdd(Blog blog)
        {
            context.Add(blog);
            context.SaveChanges();
        }

        public Blog GetById(Guid id)
        {
            return context.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            return context.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            context.Update(blog);
            context.SaveChanges();
        }
    }
}
