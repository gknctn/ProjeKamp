using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T:class
    {
        Context context = new Context(); 
        public void Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();
        }

        public T getById(int id)
        {
            return context.Set<T>().Find(id);

        }

        public List<T> GetListAll()
        {
            return context.Set<T>().ToList();
        }


        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();

            return context.Set<T>().Where(filter).ToList();
        }
        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}
