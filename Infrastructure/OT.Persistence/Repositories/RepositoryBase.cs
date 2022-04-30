using Microsoft.EntityFrameworkCore;
using OT.Application.Interfaces.Repositories;
using OT.Domain.Common;
using OT.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly AppDbContext dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
    }
}
