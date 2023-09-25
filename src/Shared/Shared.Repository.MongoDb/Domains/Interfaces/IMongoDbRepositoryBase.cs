using MongoDB.Driver;
using System.Linq.Expressions;

namespace Shared.Repository.MongoDb.Domains.Interfaces;
public interface IMongoDbRepositoryBase<T> where T : MongoEntity
{
    IMongoCollection<T> FindAll(ReadPreference? readPreference = null);
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(List<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(List<T> entities);

    #region Write
    void Add(T entity);
    void AddRange(List<T> entities);
    void Update(T entity);
    void UpdateRange(List<T> entities);
    void Delete(T entity);
    void DeleteRange(List<T> entities);
    #endregion

    #region Before write
    void BeforeAdd(T entity);
    void BeforeUpdate(T entity);
    void BeforeDelete(T entity);
    #endregion
}