
using POC_MassTransit.Application.Common.CQRS;
using POC_MassTransit.Application.Assigments.Common;

namespace POC_MassTransit.Application.Assigments.Commands.CreateAssigment;

public record CreateAssigmentCommand(AssigmentDto Assigment)
    : ICommand<CreateAssigmentResult>;

public record CreateAssigmentResult(Guid Id);