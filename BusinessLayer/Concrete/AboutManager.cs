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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About t)
        {
            throw new NotImplementedException();
        }

        public About Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetListAll(Guid id)
        {
            throw new NotImplementedException();

        }

        public object GetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void Remove(About t)
        {
            throw new NotImplementedException();
        }

        public void Update(About t)
        {
            throw new NotImplementedException();
        }
    }
}
