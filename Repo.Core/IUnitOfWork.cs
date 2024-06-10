using Repo.Core.Interface;
using Repo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepo<Author> Authors { get; }
        IBaseRepo<Book> books { get; }
        int Complete();//To save changes
    }
}
