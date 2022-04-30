using OT.Application.Interfaces.Repositories;
using OT.Domain.Entities;
using OT.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Persistence.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
