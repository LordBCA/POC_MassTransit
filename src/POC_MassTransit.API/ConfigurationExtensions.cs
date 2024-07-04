using Carter;
using Microsoft.Extensions.Configuration;

namespace POC_MassTransit.API;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        //services.AddExceptionHandler<CustomExceptionHandler>();        

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(options => { });        

        return app;
    }
}