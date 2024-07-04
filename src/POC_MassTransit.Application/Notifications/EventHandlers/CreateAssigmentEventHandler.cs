using MediatR;
using Microsoft.Extensions.Logging;
using POC_MassTransit.Application.Messaging.Events;
using POC_MassTransit.Application.Notifications.Commands.CreateNotification;
using MassTransit;
using POC_MassTransit.Application.Notifications.Common;

namespace POC_MassTransit.Application.Notifications.EventHandlers;

public class CreateAssigmentEventHandler
    (ISender sender, ILogger<CreateAssigmentEventHandler> logger)
    : IConsumer<AssigmentCreatedEvent>
{

    public async Task Consume(ConsumeContext<AssigmentCreatedEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);        

        var notificationDto = NotificationMapper.AssigmentEventToNotificationDto(context.Message);

        await sender.Send(new CreateNotificationCommand(notificationDto));
    }
}

