using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user_roles");

        builder.HasKey(ur => ur.Id);
        
        builder.Property(ur => ur.Id)
            .HasColumnName("id")
            .IsRequired(true);
        
        builder.Property(ur => ur.UserId)
            .HasColumnName("user_id")
            .IsRequired(true);
        
        builder.Property(ur => ur.RoleId)
            .HasColumnName("role_id")
            .IsRequired(true);
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();
        
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}