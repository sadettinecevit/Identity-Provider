using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("user_logins");
        
        builder.HasKey(ul => ul.Id);

        builder.Property(ul => ul.Id)
            .HasColumnName("id")
            .IsRequired(true);
        
        builder.Property(ul => ul.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(ul => ul.ProviderKey)
            .HasColumnName("provider_key")
            .IsRequired();
        
        builder.Property(ul => ul.LoginProvider)
            .HasColumnName("login_provider")
            .IsRequired();
        
        builder.Property(ul => ul.ProviderDisplayName)
            .HasColumnName("provider_display_name")
            .IsRequired();
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();
        
        builder.HasOne(ul => ul.User)
            .WithMany(u => u.Logins)
            .HasForeignKey(ul => ul.UserId);
    }
}