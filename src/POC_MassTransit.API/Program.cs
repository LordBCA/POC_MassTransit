using POC_MassTransit.API;
using POC_MassTransit.Application;
using POC_MassTransit.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var applicationAssembly = builder.Services
    .AddApplicationServices(builder.Configuration);

builder.Services
    .AddInfrastructureServices(builder.Configuration, applicationAssembly)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiServices();

//if (app.Environment.IsDevelopment())
//{
//    await app.InitialiseDatabaseAsync();
//}

app.Run();