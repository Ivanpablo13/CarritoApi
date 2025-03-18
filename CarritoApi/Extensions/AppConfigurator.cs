using CarritoApi.Application;

namespace CarritoApi.Extensions
{
    public static class AppConfigurator
    {
        public static WebApplicationBuilder ConfigureApp(WebApplicationBuilder builder)
        {
            builder.Services.ConfigurePresentation()
                .ConfigureApplication();

            return builder;
        }
    }
}
