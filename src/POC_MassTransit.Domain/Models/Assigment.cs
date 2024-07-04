using POC_MassTransit.Domain.Abstractions;

namespace POC_MassTransit.Domain.Models;

public class Assigment : Entity<Guid>
{
    public Guid UserId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int TotalHours { get; set; } = default!;
}
