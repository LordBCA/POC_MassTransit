using MediatR;

namespace POC_MassTransit.Application.Common.CQRS;
public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}