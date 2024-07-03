using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using POC_MassTransit.Application.Dtos;
using POC_MassTransit.Application.Messaging.Events;
using POC_MassTransit.Application.Notifications.Commands.CreateNotification;

namespace POC_MassTransit.Application.Assigments.EventHandlers;

public class BasketCheckoutEventHandler
    (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
    : IConsumer<AssigmentCreatedEvent>
{
    public async Task Consume(ConsumeContext<AssigmentCreatedEvent> context)
    {        
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

        var command = MapToCreateNotificationCommand(context.Message);

        await sender.Send(command);
    }

    private CreateNotificationCommand MapToCreateNotificationCommand(AssigmentCreatedEvent message)
    {
        var notificationDto = new NotificationDto(
            AssigmentId: message.AssigmentId,
            UserId: message.UserId,
            TotalHours: message.TotalHours
           );

        return new CreateNotificationCommand(notificationDto);
    }
}

