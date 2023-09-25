using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Repository.Configuration.Settings;

namespace Shared.Repository.MongoDb.Data.Interfaces;
public interface IMongoContext : IDisposable
{
    void AddCommand(Func<Task> func);
    Task<int> SaveChanges();
    IMongoCollection<T> GetCollection<T>(string name);
}
