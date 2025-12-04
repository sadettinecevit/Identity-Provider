using IdP.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace IdP.Domain.Entities;

public class UserRole : IdentityUserRole<Guid>, IBaseEntityWithId<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "system";
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } = false;
    
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}