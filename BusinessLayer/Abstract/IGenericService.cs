using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Add(T t);
        void Remove(T t);
        void Update(T t);
        List<T> GetListAll(Guid id);
        T Get(Guid id);

    }
}
