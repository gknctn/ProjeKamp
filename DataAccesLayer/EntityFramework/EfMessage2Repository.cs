using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.MessageSenderUser).Where(y => y.MessageReceiverID == id).ToList();
            }
        }

        public List<Message2> GetListWithSendMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.MessageReceiverUser).Where(y => y.MessageSenderID == id).ToList();
            }
        }
    }
}
