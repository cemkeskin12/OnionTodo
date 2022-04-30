using OT.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
    }
}
