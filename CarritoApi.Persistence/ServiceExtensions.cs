using CarritoApi.Application.Repositories;
using CarritoApi.Persistence.Context;
using CarritoApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarritoApi.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            
            services.AddScoped<ICarritoRepository, CarritoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
