using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Shared.Repository.Configuration.Settings;
using Shared.Repository.MongoDb.Data.Interfaces;

namespace Shared.Repository.MongoDb.Extensions;
public static class MongoServiceExtensions
{
    public static IServiceCollection AddMongoService(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new DatabaseSettings();
        settings.DatabaseSettingItems = configuration
                            .GetSection($"{nameof(DatabaseSettings)}:{nameof(DatabaseSettings.DatabaseSettingItems)}")
                            .Get<List<DatabaseSettingItem>>();

        services.AddSingleton(settings);

        var connectionString = settings.DatabaseSettingItems.FirstOrDefault(x => x.Name == "DefaultConnection")?.ConnectionString;
        services.AddSingleton<IMongoClient>(c =>
        {
            return new MongoClient(connectionString);
        });

        services.AddScoped(c => c.GetService<IMongoClient>().StartSession());
        return services;


    }
}
