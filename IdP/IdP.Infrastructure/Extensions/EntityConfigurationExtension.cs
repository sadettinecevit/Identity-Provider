using IdP.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Extensions;

public static class EntityConfigurationExtension
{
    public static void ConfigureEntity<T>(this EntityTypeBuilder<T> builder) where T : class, IEntity
    {
        builder.Property(e => e.IsDeleted)
            .HasColumnName("is_deleted")
            .HasDefaultValue(false)
            .IsRequired();
    }
}