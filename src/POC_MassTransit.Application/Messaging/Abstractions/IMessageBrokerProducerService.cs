﻿
namespace POC_MassTransit.Application.Messaging.Abstractions;

public interface IMessageBrokerProducerService
{
    Task PublishAsync<T>(T message) where T : class;
}
