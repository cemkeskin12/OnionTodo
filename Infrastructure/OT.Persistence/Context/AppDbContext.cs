using Microsoft.EntityFrameworkCore;
using OT.Application.Interfaces.Context;
using OT.Domain.Entities;

namespace OT.Persistence.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
    }
}
