namespace IdP.Domain.Common;

public interface IEntityWithId<TId> : IEntity
{
    public TId Id { get; set; }
}