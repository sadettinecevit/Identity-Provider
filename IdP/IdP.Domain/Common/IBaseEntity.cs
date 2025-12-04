namespace IdP.Domain.Common;

public interface IBaseEntity : IEntity, IAuditableEntity
{
    public DateTime CreatedAt { get; }
    public string CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
    
    public void MarkUpdated() => LastModifiedOn = DateTime.Now;
    public void SoftDelete() => IsDeleted = true;
}