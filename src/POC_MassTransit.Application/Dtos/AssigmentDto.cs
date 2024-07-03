namespace POC_MassTransit.Application.Dtos;

public record AssigmentDto(
    Guid Id,
    Guid UserId,
    string Name,
    int TotalHours);