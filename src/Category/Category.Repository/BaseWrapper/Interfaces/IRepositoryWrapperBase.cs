using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
namespace Category.Repository.BaseWrapper.Interfaces;
public interface IRepositoryWrapperBase : IDisposable
{
    IDbConnection GetConnection();
    Task SaveAsync(bool isAuditLog = false);
    IDbContextTransaction BeginTransaction();
    void DetachAllEntity();
    Task CommitAsync(bool isAuditLog = false);
}
