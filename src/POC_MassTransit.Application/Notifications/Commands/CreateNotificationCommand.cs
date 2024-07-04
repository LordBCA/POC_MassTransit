
using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Notifications.Common;

namespace POC_MassTransit.Application.Notifications.Commands.CreateNotification;

public record CreateNotificationCommand(NotificationDto Notification)
    : ICommand<CreateNotificationResult>;

public record CreateNotificationResult(int Id);