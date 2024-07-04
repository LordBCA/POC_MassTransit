using POC_MassTransit.Domain.Abstractions;

namespace POC_MassTransit.Domain.Models;

public class Notification : Entity<int>
{    
    public string Detail { get; set; } = default!;    
}
