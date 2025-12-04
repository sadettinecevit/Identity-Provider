using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .IsRequired(true);
        
        builder.Property(u => u.UserName)
            .HasColumnName("username")
            .IsRequired(true)
            .HasMaxLength(100);
        
        builder.Property(u => u.NormalizedUserName)
            .HasColumnName("normalized_user_name")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(u => u.PasswordHash)
            .HasColumnName("password_hash")
            .IsRequired(true);
        
        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired(true)
            .HasMaxLength(100);
        
        builder.Property(u => u.NormalizedEmail)
            .HasColumnName("normalized_email")
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(u => u.EmailConfirmed)
            .HasColumnName("email_confirmed")
            .HasDefaultValue(false)
            .IsRequired(true);
        
        builder.Property(u => u.PhoneNumber)
            .HasColumnName("phone_number")
            .HasMaxLength(100);
        
        builder.Property(u => u.PhoneNumberConfirmed)
            .HasColumnName("phone_number_confirmed")
            .HasDefaultValue(false)
            .IsRequired(true);
        
        builder.Property(u => u.AccessFailedCount)
            .HasColumnName("access_failed_count")
            .HasDefaultValue(0)
            .IsRequired(true);
        
        builder.Property(u => u.LockoutEnabled)
            .HasColumnName("lockout_enabled")
            .HasDefaultValue(false)
            .IsRequired(true);
        
        builder.Property(u => u.LockoutEnd)
            .HasColumnName("lockout_end")
            .IsRequired(false);
        
        builder.Property(u => u.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp")
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(u => u.SecurityStamp)
            .HasColumnName("security_stamp")
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.Property(u => u.TwoFactorEnabled)
            .HasColumnName("two_factor_enabled")
            .HasDefaultValue(false)
            .IsRequired(true);
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();
        
        // Relations
        builder.HasMany(u => u.Claims)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Logins)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Tokens)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}