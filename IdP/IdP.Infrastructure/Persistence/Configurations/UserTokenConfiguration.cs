using IdP.Domain.Entities;
using IdP.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdP.Infrastructure.Persistence.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("user_tokens");

        builder.HasKey(ut => ut.Id);
        
        builder.Property(ut => ut.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(ut => ut.LoginProvider)
            .HasColumnName("login_provider")
            .IsRequired();
        
        builder.Property(ut => ut.Name)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(ut => ut.Value)
            .HasColumnName("value")
            .IsRequired();
        
        builder.ConfigureAuditable();
        builder.ConfigureEntity();
        
        builder.HasOne(ut => ut.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(ut => ut.UserId);
    }
}