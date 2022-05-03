using Microsoft.EntityFrameworkCore.Storage;
using OT.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> SaveAsync();
        public IArticleRepository ArticleRepository { get; }
    }
}
