namespace IdP.Domain.Common;

public interface IEntity
{
    public bool IsDeleted { get; set; }
    
    public void SoftDelete() => IsDeleted = true;
}