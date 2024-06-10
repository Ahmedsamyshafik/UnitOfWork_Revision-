using Microsoft.EntityFrameworkCore;
using Repo.Core.Interface;
using Repo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.EF.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected readonly AppDBContext _dbContext;
        public BaseRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _dbContext.Set<T>().FirstOrDefault(match);
        }

        public T GetByID(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public T FindWithInClode(Expression<Func<T, bool>> match, string[]? includes) //may be list by using IEnumrable
        {
            IQueryable<T> q = _dbContext.Set<T>();
            foreach (var inc in includes)
            {
                q = q.Include(inc);
            }
            return q.FirstOrDefault(match);
        }

    }
}
