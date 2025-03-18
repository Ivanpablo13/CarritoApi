
using CarritoApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarritoApi.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICarritoService, CarritoService>();

            return services;
        }
    }
}
