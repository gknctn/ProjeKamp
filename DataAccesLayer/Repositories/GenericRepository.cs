using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public T getById(Guid id)
        {
            return context.Set<T>().Find(id);

        }

        public List<T> GetListAll()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Update(t);
            context = new Context();
        }
    }
}
