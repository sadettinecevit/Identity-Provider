namespace IdP.Domain.Common;

public interface IAuditableEntity
{
    public DateTime CreatedAt { get; }
    public string CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    
    public void MarkUpdated() => LastModifiedOn = DateTime.Now;
}