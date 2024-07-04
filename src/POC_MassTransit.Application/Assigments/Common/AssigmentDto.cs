namespace POC_MassTransit.Application.Assigments.Common;

public record AssigmentDto(
    Guid Id,
    Guid UserId,
    string Name,
    int TotalHours);