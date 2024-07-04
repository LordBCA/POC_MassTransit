using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace POC_MassTransit.Application;
public static class ConfigurationExtensions
{
    public static Assembly AddApplicationServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());            
        });
        
        //services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

        return Assembly.GetExecutingAssembly();
    }
}