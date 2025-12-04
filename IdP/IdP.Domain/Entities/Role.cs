using IdP.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace IdP.Domain.Entities;

public class Role : IdentityRole<Guid>, IBaseEntity
{
    public Role() { }
    public Role(string name) : base(name) { }
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "system";
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ICollection<RoleClaim> Claims { get; set; } = new List<RoleClaim>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}