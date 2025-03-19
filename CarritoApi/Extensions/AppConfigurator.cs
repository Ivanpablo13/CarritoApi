using CarritoApi.Application;
using CarritoApi.DependencyResolver;

namespace CarritoApi.Extensions
{
    public static class AppConfigurator
    {
        public static WebApplicationBuilder ConfigureApp(WebApplicationBuilder builder)
        {
            builder.Services
                .ConfigurePresentation()
                .ConfigureApplication()
                .ConfigureInfrastructure(builder.Configuration);

            return builder;
        }
    }
}
