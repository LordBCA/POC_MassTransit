using POC_MassTransit.API;
using POC_MassTransit.Application;
using POC_MassTransit.Infrastructure;
using POC_MassTransit.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();

//if (app.Environment.IsDevelopment())
//{
//    await app.InitialiseDatabaseAsync();
//}

app.Run();