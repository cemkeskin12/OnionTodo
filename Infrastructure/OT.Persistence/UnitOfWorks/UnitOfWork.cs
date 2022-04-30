using Microsoft.EntityFrameworkCore.Storage;
using OT.Application.Interfaces.Repositories;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public IArticleRepository ArticleRepository { get; }

        public UnitOfWork(AppDbContext dbContext, IArticleRepository articleRepository)
        {
            this.dbContext = dbContext;
            this.ArticleRepository = articleRepository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await dbContext.Database.BeginTransactionAsync();
        }

        public async ValueTask DisposeAsync()
        {
        }
    }
}
