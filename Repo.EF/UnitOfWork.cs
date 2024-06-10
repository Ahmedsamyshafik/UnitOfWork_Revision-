using Repo.Core;
using Repo.Core.Interface;
using Repo.Core.Models;
using Repo.EF.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        public IBaseRepo<Author> Authors { get; private set; }
        public IBaseRepo<Book> books { get; private set; }
        public UnitOfWork(AppDBContext dBContext)
        {
            _dbContext = dBContext;
            Authors = new BaseRepo<Author>(_dbContext);
            books = new BaseRepo<Book>(_dbContext);
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
