﻿using Microsoft.EntityFrameworkCore;
using POC_MassTransit.Application.Data;
using POC_MassTransit.Domain.Models;
using System.Reflection;

namespace POC_MassTransit.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Assigment> Assigments => Set<Assigment>();

    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}