namespace POC_MassTransit.Application.Notifications.Common;

public record NotificationDto(
    Guid AssigmentId,
    Guid UserId,
    int TotalHours);