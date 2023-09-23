using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shared.Repository.Configuration.Settings;
using Shared.Repository.MongoDb.Data.Interfaces;

namespace Customer.Repository;
public class RepositoryContext : IMongoContext
{
    private IMongoDatabase Database { get; set; }
    private IClientSessionHandle _session { get; set; }
    public MongoClient MongoClient { get; set; }
    private readonly List<Func<Task>> _commands;
    private readonly DatabaseSettingItem _config;
    private readonly ILogger<RepositoryContext> _logger;

    public RepositoryContext(DatabaseSettings settings, ILogger<RepositoryContext> logger, IClientSessionHandle session)
    {
        _config = settings.DatabaseSettingItems.FirstOrDefault(x => x.Name == "DefaultConnection");

        // Every command will be stored and it'll be processed at SaveChanges
        _commands = new List<Func<Task>>();
        _logger = logger;
        _session = session;
    }

    public async Task<int> SaveChanges()
    {
        ConfigureMongo();

        _session.StartTransaction();

        try
        {
            var commandTasks = _commands.Select(c => c());

            await Task.WhenAll(commandTasks);
            await _session.CommitTransactionAsync();
        }
        catch (NotSupportedException e)
        {
            _logger.LogError(e.Message);
        }
        catch (Exception ex)
        {
            var type = ex.GetType();
            await _session.AbortTransactionAsync();
            throw;
        }
        return _commands.Count;
    }

    private void ConfigureMongo()
    {
        if (MongoClient != null)
        {
            return;
        }

        // Configure mongo (You can inject the config, just to simplify)
        MongoClient = new MongoClient(_config.ConnectionString);

        Database = MongoClient.GetDatabase(_config.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        ConfigureMongo();

        return Database.GetCollection<T>(name);
    }

    public void Dispose()
    {
        _session?.Dispose();
        GC.SuppressFinalize(this);
    }

    public void AddCommand(Func<Task> func)
    {
        _commands.Add(func);
    }
}
