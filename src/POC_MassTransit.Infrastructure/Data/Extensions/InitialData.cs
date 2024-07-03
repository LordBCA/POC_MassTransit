using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Assigment> Assigments =>
    new List<Assigment>
    {
        Assigment.Create(new Guid("58c49479-ec65-4de2-86e7-033c546291aa"), "mehmet", 16),
        Assigment.Create(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), "john", 12)
    };
}