using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Application.Messaging.Abstractions;
using POC_MassTransit.Application.Messaging.Events;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Application.Assigments.Commands.CreateAssigment;
public class CreateAssigmentHandler(IApplicationDbContext dbContext, IMessageBrokerService messageBrokerService)
    : ICommandHandler<CreateAssigmentCommand, CreateAssigmentResult>
{
    public async Task<CreateAssigmentResult> Handle(CreateAssigmentCommand command, CancellationToken cancellationToken)
    {        
        var assigment = Assigment.Create(
            command.Assigment.UserId, 
            command.Assigment.Name, 
            command.Assigment.TotalHours
        );

        dbContext.Assigments.Add(assigment);
        await dbContext.SaveChangesAsync(cancellationToken);

        var eventMessage = new AssigmentCreatedEvent 
        {
            AssigmentId = assigment.Id,
            UserId = assigment.UserId,
            TotalHours = assigment.TotalHours
        };        

        await messageBrokerService.PublishAsync(eventMessage);

        return new CreateAssigmentResult(assigment.Id);
    }
}