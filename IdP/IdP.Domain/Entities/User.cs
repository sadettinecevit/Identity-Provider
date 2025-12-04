using IdP.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace IdP.Domain.Entities;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "system";
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    public virtual ICollection<UserLogin> Logins { get; set; } = new List<UserLogin>();
    public virtual ICollection<UserToken> Tokens { get; set; } = new List<UserToken>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}