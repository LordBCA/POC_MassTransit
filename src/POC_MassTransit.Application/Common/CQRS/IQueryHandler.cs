﻿using MediatR;

namespace POC_MassTransit.Application.Common.CQRS;
public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}