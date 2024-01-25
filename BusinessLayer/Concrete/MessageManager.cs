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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _messageDal.GetListAll(x=>x.MessageReceiver==p);
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _messageDal.getById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetListAll();
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
