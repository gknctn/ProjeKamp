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

        public void CommentAdd(Comment comment)
        {
            _commentdal.Insert(comment);
        }

        public List<Comment> GetListAll(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }

        public void TAdd(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public Blog TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }
    }
}
