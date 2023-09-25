using Shared.Repository.MongoDb.Domains.Interfaces;

namespace Shared.Repository.MongoDb.Domains;
public abstract class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; }
}