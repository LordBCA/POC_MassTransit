using POC_MassTransit.Application.Assigments.Common;
using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Application.Messaging.Abstractions;

namespace POC_MassTransit.Application.Assigments.Commands.CreateAssigment;
public class CreateAssigmentHandler(IApplicationDbContext dbContext, IMessageBrokerService messageBrokerService)
    : ICommandHandler<CreateAssigmentCommand, CreateAssigmentResult>
{
    public async Task<CreateAssigmentResult> Handle(CreateAssigmentCommand command, CancellationToken cancellationToken)
    {        
        var assigment = AssigmentMapper.AssigmentDtoToModel(command.Assigment);        

        dbContext.Assigments.Add(assigment);
        await dbContext.SaveChangesAsync(cancellationToken);        

        var eventMessage = AssigmentMapper.AssigmenttoEvent(assigment);

        await messageBrokerService.PublishAsync(eventMessage);

        return new CreateAssigmentResult(assigment.Id);
    }
}