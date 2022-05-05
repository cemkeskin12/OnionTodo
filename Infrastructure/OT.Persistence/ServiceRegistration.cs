using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OT.Application.Features.DependencyInjection;
using OT.Application.Interfaces.Context;
using OT.Application.Interfaces.Repositories;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Persistence.Context;
using OT.Persistence.Repositories;
using OT.Persistence.UnitOfWorks;

namespace OT.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());


            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
