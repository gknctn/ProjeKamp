using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        //void CommentRemove(Comment comment);
        //void CommentUpdate(Comment comment);
        List<Comment> GetListAll(Guid id);
        //Comment GetComment(Guid id);
    }
}
