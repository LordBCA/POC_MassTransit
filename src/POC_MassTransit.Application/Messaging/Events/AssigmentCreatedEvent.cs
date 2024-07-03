namespace POC_MassTransit.Application.Messaging.Events;
public record AssigmentCreatedEvent : IntegrationEvent
{
    public Guid AssigmentId { get; set; } = default!;
    public Guid UserId { get; set; } = default!;
    public int TotalHours { get; set; } = default!;
}
