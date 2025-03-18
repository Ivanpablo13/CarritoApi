namespace CarritoApi.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigurePresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
