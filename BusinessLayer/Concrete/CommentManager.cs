using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public List<Comment> GetCommentListWithBlog()
        {
            return _commentdal.GetCommentListAndBlog();
        }

        public List<Comment> GetListAll(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }

        public void TAdd(Comment t)
        {
            _commentdal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentdal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentdal.getById(id);
        }

        public List<Comment> TGetList()
        {
            return _commentdal.GetListAll();
        }

        public void TUpdate(Comment t)
        {
            _commentdal.Update(t);
        }
    }
}
