using MassTransit;
using POC_MassTransit.Application.Assigments.Common;
using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Data;

namespace POC_MassTransit.Application.Assigments.Commands.CreateAssigment;
public class CreateAssigmentHandler(IApplicationDbContext dbContext, IPublishEndpoint messageBrokerService)
    : ICommandHandler<CreateAssigmentCommand, CreateAssigmentResult>
{
    public async Task<CreateAssigmentResult> Handle(CreateAssigmentCommand command, CancellationToken cancellationToken)
    {        
        var assigment = AssigmentMapper.AssigmentDtoToModel(command.Assigment);        

        await dbContext.Assigments.AddAsync(assigment);              

        var eventMessage = AssigmentMapper.AssigmenttoEvent(assigment);

        await messageBrokerService.Publish(eventMessage, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateAssigmentResult(assigment.Id);
    }
}