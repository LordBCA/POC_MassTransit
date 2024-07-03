using POC_MassTransit.Domain.Abstractions;

namespace POC_MassTransit.Domain.Models;

public class Assigment : Entity<Guid>
{
    public Guid UserId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public int TotalHours { get; private set; } = default!;

    public static Assigment Create(Guid userId, string name, int totalHours)
    {
        var assigment = new Assigment
        {            
            UserId = userId,
            Name = name,
            TotalHours = totalHours            
        };        

        return assigment;
    }
}
