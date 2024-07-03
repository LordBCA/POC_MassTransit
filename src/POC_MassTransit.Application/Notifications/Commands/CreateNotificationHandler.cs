using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Application.Notifications.Commands.CreateNotification;
public class CreateNotificationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateNotificationCommand, CreateNotificationResult>
{
    public async Task<CreateNotificationResult> Handle(CreateNotificationCommand command, CancellationToken cancellationToken)
    {        
        var notification = Notification.Create(
            $"Task created with Id number:{command.Notification.AssigmentId} for a total of {command.Notification.TotalHours} hours."            
        );

        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync(cancellationToken);        

        return new CreateNotificationResult(notification.Id);
    }
}