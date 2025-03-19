using Microsoft.Extensions.DependencyInjection;
using CarritoApi.Persistence;
using CarritoApi.Application;
using Microsoft.Extensions.Configuration;
using CarritoApi.Application.Services;

namespace CarritoApi.DependencyResolver
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigurePersistence(configuration)
                .ConfigureServices(configuration);

            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
             .AddScoped<ICarritoService, CarritoService>();

            return services;
        }

    }
}
