using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_MassTransit.Infrastructure.Data;
using POC_MassTransit.Infrastructure.Messaging.Configurations;
using POC_MassTransit.Infrastructure.State;
using System.Reflection;


namespace POC_MassTransit.Infrastructure.Messaging;
public static class MessageBrokerExtensions
{
    public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
    {
        var messageBrokerOptions = configuration.GetSection("MessageBroker").Get<MessageBrokerOptions>();

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumers(assembly);
            //config.AddActivities(assembly);

            config.AddEntityFrameworkOutbox<ApplicationDbContext>(o =>
            {
                o.QueryDelay = TimeSpan.FromSeconds(1);
                o.UseSqlServer();
                //o.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
                //o.DisableInboxCleanupService();
                // enable the bus outbox
                o.UseBusOutbox();
            });           

            //config.AddSagaStateMachine<RegistrationStateMachine, RegistrationState, RegistrationStateDefinition>()
            //    .EntityFrameworkRepository(r =>
            //    {
            //        r.ExistingDbContext<ApplicationDbContext>();
            //        r.UseSqlServer();
            //    });

            MessageBrokerConfiguratorFactory.Create(config, messageBrokerOptions).Configure();

            //config.AddConfigureEndpointsCallback((context, name, cfg) =>
            //{
            //    cfg.UseMessageRetry(r => r.Intervals(100, 500, 1000, 5000, 10000));
            //    cfg.UseEntityFrameworkOutbox<ApplicationDbContext>(context);
            //});

            //switch (messageBrokerOptions.Service)
            //{
            //    case "AzureServiceBus":
            //        config.UsingAzureServiceBus((context, configurator) =>
            //        {
            //            configurator.Host(messageBrokerOptions.ConnectionString);
            //            configurator.ConfigureEndpoints(context);
            //        });
            //        break;
            //    case "RabbitMQ":
            //        config.UsingRabbitMq((context, configurator) =>
            //        {
            //            configurator.Host(new Uri(messageBrokerOptions.Host!), host =>
            //            {
            //                host.Username(messageBrokerOptions.UserName);
            //                host.Password(messageBrokerOptions.Password);
            //            });
            //            configurator.ConfigureEndpoints(context);


            //        });
            //        break;
            //    default:
            //        config.UsingInMemory();
            //        break;
            //}


        });

        //services.AddMassTransitHostedService();

        return services;
    }
}
