using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Blog>
    {
        void CommentAdd(Comment comment);
        //void CommentRemove(Comment comment);
        //void CommentUpdate(Comment comment);
        List<Comment> GetListAll(int id);
        //Comment GetComment(Guid id);
    }
}
