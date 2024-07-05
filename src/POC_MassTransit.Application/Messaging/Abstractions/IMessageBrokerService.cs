
namespace POC_MassTransit.Application.Messaging.Abstractions;

public interface IMessageBrokerService
{
    Task PublishAsync<T>(T message) where T : class;    
}
