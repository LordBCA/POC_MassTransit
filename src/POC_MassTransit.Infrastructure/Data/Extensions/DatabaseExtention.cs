//using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace POC_MassTransit.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    //public static async Task InitialiseDatabaseAsync(this WebApplication app)
    //{
    //    using var scope = app.Services.CreateScope();

    //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //    context.Database.MigrateAsync().GetAwaiter().GetResult();

    //    await SeedAsync(context);
    //}

    //private static async Task SeedAsync(ApplicationDbContext context)
    //{
    //    await SeedAssigmentAsync(context);
    //}

    //private static async Task SeedAssigmentAsync(ApplicationDbContext context)
    //{
    //    if (!await context.Assigments.AnyAsync())
    //    {
    //        await context.Assigments.AddRangeAsync(InitialData.Assigments);
    //        await context.SaveChangesAsync();
    //    }
    //}
}