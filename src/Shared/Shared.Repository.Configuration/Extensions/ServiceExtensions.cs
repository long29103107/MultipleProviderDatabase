using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Shared.Repository.Configuration.Constants;
using Shared.Repository.Configuration.Settings;
using System.Reflection;

namespace Shared.Repository.Configuration.Extensions;
public static class ServiceExtensions
{
    /// <summary>
    /// Get options by section name in appsettings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <param name="sectionName"></param>
    /// <returns></returns>
    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();

        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        var section = configuration.GetSection(sectionName);

        var options = new T();

        section.Bind(options);

        return options;
    }

    /// <summary>
    /// Add DbContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <param name="defaultOption"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigDatabaseProvider<T>(this IServiceCollection services
        , IConfiguration configuration
        , DatabaseSettingItem defaultOption
        , string assemblyName = "")
        where T : DbContext
    {
        if (defaultOption.DBProvider == DatabaseConstants.Providers.SqlServer)
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(defaultOption.ConnectionString,
                        builder => builder.MigrationsAssembly(typeof(T).Assembly.FullName));
            });
        }
        else if (defaultOption.DBProvider == DatabaseConstants.Providers.Postgres)
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(defaultOption.ConnectionString,
                        builder => builder.MigrationsAssembly(typeof(T).Assembly.FullName));
            });
        }
        else if (defaultOption.DBProvider == DatabaseConstants.Providers.MySql)
        {
            var builder = new MySqlConnectionStringBuilder(defaultOption.ConnectionString);

            if(string.IsNullOrEmpty(assemblyName))
            {
                throw new Exception("Mysql must have assembly name");
            }    

            services.AddDbContext<T>(m => m.UseMySql(builder.ConnectionString,
                ServerVersion.AutoDetect(builder.ConnectionString), e =>
                {
                    e.MigrationsAssembly(assemblyName);
                    e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                }));

        }

        return services;
    }

    /// <summary>
    /// Get configuration database settings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static DatabaseSettings GetDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var result = new DatabaseSettings();
        result.DatabaseSettingItems = configuration
                            .GetSection($"{nameof(DatabaseSettings)}:{nameof(DatabaseSettings.DatabaseSettingItems)}")
                            .Get<List<DatabaseSettingItem>>();

        services.AddSingleton(result);
        return result;
    }

    /// <summary>
    /// Configure DbContext in service of the api 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection ConfigureDbContext<T>(this IServiceCollection services
        , IConfiguration configuration
        , string assemblyName = "")
    where T : DbContext
    {
        var settings = services.GetDatabaseSettings(configuration);

        ValidateSettings(settings);

        if (!settings.DatabaseSettingItems.Any())
        {
            throw new Exception("Not found any database settings");
        }

        DatabaseSettingItem defaultOption = settings.DatabaseSettingItems.FirstOrDefault(x => x.Name.Equals(DatabaseConstants.Connections.Default));

        if (defaultOption == null || string.IsNullOrEmpty(defaultOption?.ConnectionString))
        {
            throw new Exception("Not found any database settings");
        }

        services.ConfigDatabaseProvider<T>(configuration, defaultOption, assemblyName);

        return services;
    }

    public static void ValidateSettings(DatabaseSettings settings)
    {
        var providers = settings.DatabaseSettingItems.Select(x => x.DBProvider).Distinct().ToList();

        var allowedProvider = new List<string>()
        {
             DatabaseConstants.Providers.SqlServer,
             DatabaseConstants.Providers.Mongo,
             DatabaseConstants.Providers.MySql,
             DatabaseConstants.Providers.Postgres,
        };

        var inValidProviders = providers.Where(x => !allowedProvider.Contains(x))
                                            .Select(x => x)
                                            .ToList();

        if (inValidProviders.Any())
        {
            if (inValidProviders.Count > 1)
            {
                throw new Exception($"Provider {string.Join(",", inValidProviders)} don't support");
            }
            else
            {
                throw new Exception($"Provider {string.Join(",", inValidProviders)} doesn't support");
            }
        }
    }
}
