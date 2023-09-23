using Customer.Repository;
using Customer.Repository.Interfaces;
using MongoDB.Driver;

namespace Customer.Api.Extensions;

public static class ServiceExtensions
{
    private static string GetMongoConnectionString(this IServiceCollection services
        , IConfiguration configuration
        , string sectionName)
    {
        //var settings = services.GetDatabaseSettings(configuration).DatabaseSettingItem
        //                            .FirstOrDefault( x => x.Name == sectionName);

        //if (settings == null || string.IsNullOrEmpty(settings.ConnectionString))
        //    throw new ArgumentNullException("MongoDbSettings is not confugured");

        //var databaseName = settings.DatabaseName;
        //var mongoDbConnectionString = settings.ConnectionString + "/" + databaseName + "?authSource=admin";

        //return mongoDbConnectionString;
        return string.Empty;
    }

    public static void ConfigureMongoDbClient(this IServiceCollection services
        , IConfiguration configuration
        , string sectionName = "DefaultConnection")
    {
        services.AddSingleton<IMongoClient>(new MongoClient(GetMongoConnectionString(services, configuration, sectionName)));
        services.AddScoped(x => x.GetService<MongoClient>()?.StartSession());
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        ////DatabaseSettings mongoDbSettings = services.GetDatabaseSettings(configuration);
        ////services.AddSingleton(mongoDbSettings);

        return services;
    }
}
