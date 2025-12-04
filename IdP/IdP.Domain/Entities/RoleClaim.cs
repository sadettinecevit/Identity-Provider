using IdP.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace IdP.Domain.Entities;

public class RoleClaim : IdentityRoleClaim<Guid>, IBaseEntity
{
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "system";
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } = false;
    
    public virtual Role Role { get; set; }
}