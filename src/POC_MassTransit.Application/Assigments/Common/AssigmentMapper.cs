using POC_MassTransit.Application.Messaging.Events;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Application.Assigments.Common;

public static class AssigmentMapper
{
    public static Assigment AssigmentDtoToModel(AssigmentDto assigmentDto)
    {
        return new Assigment
        {
            UserId = assigmentDto.UserId,
            Name = assigmentDto.Name,
            TotalHours = assigmentDto.TotalHours
        };
    }
    public static AssigmentCreatedEvent AssigmenttoEvent(Assigment assigment)
    {
        return new AssigmentCreatedEvent
        {
            AssigmentId = assigment.Id,
            UserId = assigment.UserId,
            TotalHours = assigment.TotalHours
        };
    }
}
