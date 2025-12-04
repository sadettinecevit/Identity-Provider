using System.Linq.Expressions;
using System.Reflection;
using IdP.Domain.Common;
using IdP.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdP.Infrastructure.Persistence;

public class IdPDbContext(DbContextOptions<IdPDbContext> options) : IdentityDbContext<User, Role, Guid,
    UserClaim, UserRole, UserLogin,
    RoleClaim, UserToken>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Apply query filters to all entities that implement
        foreach (var entityTypeClrType in builder.Model.GetEntityTypes().Where(e => typeof(IEntity).IsAssignableFrom(e.ClrType)).Select(e => e.ClrType))
        {
            builder.Entity(entityTypeClrType)
                .HasQueryFilter(
                    Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(Expression.Parameter(entityTypeClrType),
                                nameof(IEntity.IsDeleted)),
                            Expression.Constant(false)
                        ),
                        Expression.Parameter(entityTypeClrType)
                    )
                );
        }
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
}
