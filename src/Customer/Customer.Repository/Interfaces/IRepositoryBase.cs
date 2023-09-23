using System.Linq.Expressions;
namespace Customer.Repository.Interfaces;
public interface IRepositoryBase<T> : IDisposable where T : class
{
    Task AddAsync(T obj);
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task UpdateAsync(T obj);
    Task RemoveAsync(string id);
}