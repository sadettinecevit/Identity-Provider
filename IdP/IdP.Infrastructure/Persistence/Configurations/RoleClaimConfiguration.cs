using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("role_claims");

        builder.HasKey(rc => rc.Id);
        
        builder.Property(rc => rc.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(rc => rc.RoleId)
            .HasColumnName("role_id")
            .IsRequired();
        
        builder.Property(rc => rc.ClaimType)
            .HasColumnName("claim_type")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.Property(rc => rc.ClaimValue)
            .HasColumnName("claim_value")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();

        builder.HasOne(rc => rc.Role)
            .WithMany(r => r.Claims)
            .HasForeignKey(rc => rc.RoleId);
    }
}