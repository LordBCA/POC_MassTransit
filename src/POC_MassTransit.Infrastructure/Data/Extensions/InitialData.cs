using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Assigment> Assigments =>
    new List<Assigment>
    {
        new Assigment {Id = new Guid("58c49479-ec65-4de2-86e7-033c546291aa"), UserId = new Guid("815f807b-616f-4b2c-91f4-95957e60930a"), TotalHours = 16 },
        new Assigment {Id = new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d"), UserId = new Guid("815f807b-616f-4b2c-91f4-95957e60930a"), TotalHours = 12 }
    };
}