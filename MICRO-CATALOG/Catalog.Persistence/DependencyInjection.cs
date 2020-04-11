using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spk.Catalog.Application.Common.Interfaces;

namespace Spk.Catalog.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CatalogDatabase")));

            services.AddScoped<ICatalogDbContext>(provider => provider.GetService<CatalogDbContext>());

            return services;
        }
    }
}
