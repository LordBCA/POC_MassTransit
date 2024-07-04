using POC_MassTransit.Application.Messaging.Events;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Application.Notifications.Common;

public static class NotificationMapper
{
    public static Notification NotificationDtoToModel(NotificationDto notificationDto)
    {
        return new Notification
        {
            Detail = $"Task created with Id number:{notificationDto.AssigmentId} for a total of {notificationDto.TotalHours} hours."
        };
    }

    public static NotificationDto AssigmentEventToNotificationDto(AssigmentCreatedEvent eventMessage)
    {
        return new NotificationDto
        (
            AssigmentId: eventMessage.AssigmentId,
            UserId: eventMessage.UserId,
            TotalHours: eventMessage.TotalHours
        );
    }
}
