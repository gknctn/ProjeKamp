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
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void TAdd(AppUser t)
        {
            _userdal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _userdal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _userdal.getById(id);
        }

        public List<AppUser> TGetList()
        {
            return _userdal.GetListAll();
        }

        public void TUpdate(AppUser t)
        {
            _userdal.Update(t);
        }
    }
}
