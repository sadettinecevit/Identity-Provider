using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("user_claims");

        builder.HasKey(uc => uc.Id);

        builder.Property(uc => uc.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.Property(uc => uc.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(uc => uc.ClaimType)
            .HasColumnName("claim_type")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.Property(uc => uc.ClaimValue)
            .HasColumnName("claim_value")
            .HasMaxLength(256)
            .IsRequired(false);
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.Claims)
            .HasForeignKey(uc => uc.UserId);
    }
}