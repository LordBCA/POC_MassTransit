namespace POC_MassTransit.Application.Dtos;

public record NotificationDto(
    Guid AssigmentId,
    Guid UserId,    
    int TotalHours);