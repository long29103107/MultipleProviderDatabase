using Microsoft.EntityFrameworkCore;
using Basket.Repository.Interfaces;
using System.Linq.Expressions;
namespace Basket.Repository;
public abstract class RepositoryBase<T, K> : IRepositoryBase<T>
    where T : class
    where K : DbContext
{
    protected K _context { get; set; }
    public RepositoryBase(K context)
    {
        _context = context;
    }
    #region Filter
    public virtual IQueryable<T> Filter()
    {
        return _context.Set<T>();
    }
    #endregion
    #region Queryable
    public IQueryable<T> FindAll(bool isTracking = false)
    {
        if (!isTracking)
        {
            return _context.Set<T>().AsNoTracking();
        }
        return _context.Set<T>();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (!isTracking)
        {
            return this.Filter().AsNoTracking().Where(expression);
        }
        return Filter().Where(expression);
    }
    #endregion
    #region Read
    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (!isTracking)
        {
            return await this.Filter().AsNoTracking().FirstOrDefaultAsync(expression);
        }
        return await this.Filter().FirstOrDefaultAsync(expression);
    }
    public async Task<T> FirstOrDefaultAsync(bool isTracking = false)
    {
        if (!isTracking)
        {
            return await this.Filter().AsNoTracking().FirstOrDefaultAsync();
        }
        return await this.Filter().FirstOrDefaultAsync();
    }
    public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (!isTracking)
        {
            return await this.Filter().AsNoTracking().SingleOrDefaultAsync(expression);
        }
        return await this.Filter().SingleOrDefaultAsync(expression);
    }
    public async Task<T> SingleOrDefaultAsync(bool isTracking = false)
    {
        if (!isTracking)
        {
            return await this.Filter().AsNoTracking().SingleOrDefaultAsync();
        }
        return await this.Filter().SingleOrDefaultAsync();
    }
    public T FirstOrDefault(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (!isTracking)
        {
            return this.Filter().AsNoTracking().FirstOrDefault(expression);
        }
        return this.Filter().FirstOrDefault(expression);
    }
    public T FirstOrDefault(bool isTracking = false)
    {
        if (!isTracking)
        {
            return this.Filter().AsNoTracking().FirstOrDefault();
        }
        return this.Filter().FirstOrDefault();
    }
    public T SingleOrDefault(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        if (!isTracking)
        {
            return this.Filter().AsNoTracking().SingleOrDefault(expression);
        }
        return this.Filter().AsNoTracking().SingleOrDefault(expression);
    }
    public T SingleOrDefault(bool isTracking = false)
    {
        if (!isTracking)
        {
            return this.Filter().AsNoTracking().SingleOrDefault();
        }
        return this.Filter().SingleOrDefault();
    }
    #endregion
    #region Tracking
    public void Attach(T entity)
    {
        _context.Set<T>().Attach(entity);
    }
    public void Detach(T entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
    }
    public void DetachRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
    #endregion
    #region Write
    public void Add(T entity)
    {
        this.BeforeAdd(entity);
        _context.Set<T>().Add(entity);
    }
    public void AddRange(List<T> entities)
    {
        foreach (var entity in entities)
            this.BeforeAdd(entity);
        _context.Set<T>().AddRange(entities);
    }
    public void Update(T entity)
    {
        this.BeforeUpdate(entity);
        _context.Set<T>().Update(entity);
    }
    public void UpdateRange(List<T> entities)
    {
        foreach (var entity in entities)
            this.BeforeUpdate(entity);
        _context.Set<T>().UpdateRange(entities);
    }
    public void Delete(T entity)
    {
        this.BeforeDelete(entity);
        _context.Set<T>().Remove(entity);
    }
    public void DeleteRange(List<T> entities)
    {
        if (entities == null)
            return;
        foreach (var entity in entities)
            this.BeforeDelete(entity);
        _context.Set<T>().RemoveRange(entities);
    }
    #endregion
    #region Before write
    public virtual void BeforeAdd(T entity)
    {
    }
    public virtual void BeforeUpdate(T entity)
    {
    }
    public virtual void BeforeDelete(T entity)
    {
    }
    #endregion
}
