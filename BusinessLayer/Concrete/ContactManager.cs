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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact t)
        {
            _contactDal.Insert(t);
        }

        public Contact Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetListAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Contact t)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
