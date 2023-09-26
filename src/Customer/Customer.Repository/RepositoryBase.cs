using Microsoft.EntityFrameworkCore;
using Customer.Repository.Interfaces;
using MongoDB.Driver;
using Shared.Repository.MongoDb.Data.Interfaces;
using SharpCompress.Common;
using System.Linq.Expressions;
using Shared.Repository.MongoDb.Domains;

namespace Customer.Repository;
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : MongoEntity
{
    protected readonly IMongoContext Context;
    protected IMongoCollection<T> DbSet;

    protected RepositoryBase(IMongoContext context)
    {
        Context = context;
        DbSet = Context.GetCollection<T>(typeof(T).Name);
    }

    public virtual async Task AddAsync(T obj)
    {
        await DbSet.InsertOneAsync(obj);
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        var data = await DbSet.FindAsync(x => x.Id == id);
        return data.SingleOrDefault();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task UpdateAsync(T obj)
    {
        Expression<Func<T, string>> func = f => f.Id;

        var value = (string)obj.GetType()
            .GetProperty(func.Body.ToString()
            .Split(".")[1])?.GetValue(obj, null);

        var filter = Builders<T>.Filter.Eq(func, value);
        await DbSet.ReplaceOneAsync(filter, obj);
    }

    public virtual async Task RemoveAsync(string id)
    {
        await DbSet.DeleteOneAsync(x => x.Id.Equals(id));
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}
