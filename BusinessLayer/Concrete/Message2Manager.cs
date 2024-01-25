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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _Message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _Message2Dal = message2Dal;
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _Message2Dal.GetListWithMessageByWriter(id);
        }
        public List<Message2>GetSendboxListByWriter(int id) 
        {
            return _Message2Dal.GetListWithSendMessageByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _Message2Dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            _Message2Dal.Delete(t);
        }

        public Message2 TGetById(int id)
        {
            return _Message2Dal.getById(id);
        }

        public List<Message2> TGetList()
        {
            return _Message2Dal.GetListAll();
        }

        public void TUpdate(Message2 t)
        {
            _Message2Dal.Update(t);
        }
    }
}
