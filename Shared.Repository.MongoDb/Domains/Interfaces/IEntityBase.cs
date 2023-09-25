namespace Shared.Repository.MongoDb.Domains.Interfaces;
public interface IEntityBase<T>
{
    T Id { get; set; }
}
