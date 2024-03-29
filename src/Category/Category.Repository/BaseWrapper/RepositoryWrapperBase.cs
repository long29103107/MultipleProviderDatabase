using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Category.Repository.BaseWrapper.Interfaces;
namespace Category.Repository.BaseWrapper;
public class RepositoryWrapperBase<T> : IRepositoryWrapperBase where T : DbContext
{
    protected bool _isAuditLog = false; // When = true, isAuditLog param on SaveAsync method is ignored
    private bool _disposed = false;
    protected T _dbContext { get; set; }
    public RepositoryWrapperBase(T dbContext)
    {
        _dbContext = dbContext;
    }
    public IDbConnection GetConnection()
    {
        return _dbContext.Database.GetDbConnection();
    }
    public void DetachAllEntity()
    {
        var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
          .Where(e => e.State == EntityState.Added ||
                      e.State == EntityState.Modified ||
                      e.State == EntityState.Deleted ||
                      e.State == EntityState.Unchanged)
          .ToList();
        foreach (var entry in changedEntriesCopy)
        {
            entry.State = EntityState.Detached;
        }
    }
    public async Task SaveAsync(bool isAuditLog = false)
    {
        await _dbContext.SaveChangesAsync();
    }
    public void Save(bool isAuditLog = false)
    {
        _dbContext.SaveChanges();
    }
    public IDbContextTransaction BeginTransaction()
    {
        return _dbContext.Database.BeginTransaction();
    }
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public async Task CommitAsync(bool isAuditLog = false)
    {
        await _dbContext.Database.CommitTransactionAsync();
    }
}
