using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC_MassTransit.Application;
using POC_MassTransit.Infrastructure;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((Action<HostBuilderContext, IServiceCollection>)((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        var applicationAssembly = services
            .AddApplicationServices(configuration);

        services
            .AddInfrastructureServices(configuration, applicationAssembly);
            
    }))
    .Build();

host.Run();
