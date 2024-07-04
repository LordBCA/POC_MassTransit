using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POC_MassTransit.Domain.Models;

namespace POC_MassTransit.Infrastructure.Data.Configurations;
public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id);

        builder.Property(c => c.Detail).HasMaxLength(300).IsRequired();        
    }
}
