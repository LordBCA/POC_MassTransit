﻿using Microsoft.EntityFrameworkCore;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Assigment> Assigments { get; }
    DbSet<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}