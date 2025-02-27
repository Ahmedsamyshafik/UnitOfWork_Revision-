﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Core.Interface
{
    public interface IBaseRepo<T> where T : class
    {
           
        T GetByID(int id);
        T Find(Expression<Func<T, bool>> match);
        T FindWithInClode(Expression<Func<T, bool>> match, string[]? includes);

    }
}
