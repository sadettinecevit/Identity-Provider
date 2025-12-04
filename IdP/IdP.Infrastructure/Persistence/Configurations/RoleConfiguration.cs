using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .IsRequired(true);
        
        builder.Property(r => r.Name)
            .HasColumnName("name")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.Property(r => r.NormalizedName)
            .HasColumnName("normalized_name")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.Property(r => r.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp")
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();
        
        builder.HasMany(r => r.Claims)
            .WithOne(rc => rc.Role)
            .HasForeignKey(rc => rc.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}