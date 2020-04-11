using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Infrastructure.Notifications;

namespace Spk.Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
