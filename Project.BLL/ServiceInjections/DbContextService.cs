
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;

namespace Project.BLL.ServiceInjections
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<MyContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("MyConnection")
                )
                .UseLazyLoadingProxies();
            });

            return services;
        }
    }
}
