using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Application.Notifications.Common;

namespace POC_MassTransit.Application.Notifications.Commands.CreateNotification;
public class CreateNotificationHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateNotificationCommand, CreateNotificationResult>
{
    public async Task<CreateNotificationResult> Handle(CreateNotificationCommand command, CancellationToken cancellationToken)
    {
        var notification = NotificationMapper.NotificationDtoToModel(command.Notification);

        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync(cancellationToken);        

        return new CreateNotificationResult(notification.Id);
    }
}