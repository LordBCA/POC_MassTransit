﻿using MediatR;

namespace POC_MassTransit.Application.Common.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
