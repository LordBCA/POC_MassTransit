using POC_MassTransit.Domain.Abstractions;

namespace POC_MassTransit.Domain.Models;

public class Notification : Entity<int>
{    
    public string Detail { get; private set; } = default!; 

    public static Notification Create(string detail)
    {
        var notification = new Notification
        {            
            Detail = detail            
        };        

        return notification;
    }
}
