using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();

        public void CategoryAdd(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public void CategoryRemove(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }

        public Category GetById(Guid id)
        {
            return context.Categories.Find(id);
        }

        public List<Category> ListAllCategory()
        {
            return context.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }

    }
}
