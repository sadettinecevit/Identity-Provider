using IdP.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Extensions;

public static class AuditConfigurationExtensions
{
    public static void ConfigureAuditable<T>(this EntityTypeBuilder<T> builder) where T : class, IAuditableEntity
    {
        builder.Property(ut => ut.CreatedBy)
            .HasColumnName("created_by")
            .IsRequired();

        builder.Property(ut => ut.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(ut => ut.LastModifiedBy)
            .HasColumnName("last_modified_by")
            .IsRequired(false);

        builder.Property(ut => ut.LastModifiedOn)
            .HasColumnName("last_modified_on")
            .IsRequired(false);
    }
}