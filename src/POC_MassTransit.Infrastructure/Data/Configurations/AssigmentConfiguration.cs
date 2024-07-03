using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Infrastructure.Data.Configurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Assigment>
{
    public void Configure(EntityTypeBuilder<Assigment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.TotalHours);
    }
}
