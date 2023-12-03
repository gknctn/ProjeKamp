﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T>where T :class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetListAll();
        T getById(Guid id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
