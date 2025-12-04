namespace IdP.Domain.Common;

public interface IBaseEntityWithId<TId> : IEntityWithId<TId>, IAuditableEntity
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; }
    public string CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
    
    public void MarkUpdated() => LastModifiedOn = DateTime.Now;
    public void SoftDelete() => IsDeleted = true;
}