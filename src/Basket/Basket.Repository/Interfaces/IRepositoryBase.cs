using System.Linq.Expressions;
namespace Basket.Repository.Interfaces;
public interface IRepositoryBase<T>
{
    #region Filter
    IQueryable<T> Filter();
    #endregion
    #region Queryable
    IQueryable<T> FindAll(bool isTracking = false);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false);
    #endregion
    #region Read
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false);
    Task<T> FirstOrDefaultAsync(bool isTracking = false);
    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false);
    Task<T> SingleOrDefaultAsync(bool isTracking = false);
    T FirstOrDefault(Expression<Func<T, bool>> expression, bool isTracking = false);
    T FirstOrDefault(bool isTracking = false);
    T SingleOrDefault(Expression<Func<T, bool>> expression, bool isTracking = false);
    T SingleOrDefault(bool isTracking = false);
    #endregion
    #region Tracking
    void Attach(T entity);
    void Detach(T entity);
    void DetachRange(List<T> entities);
    #endregion
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
