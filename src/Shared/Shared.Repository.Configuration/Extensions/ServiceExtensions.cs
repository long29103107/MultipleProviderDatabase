using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository.Configuration.Constants;
using Shared.Repository.Configuration.Settings;

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
    /// Get configuration database settings
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static DatabaseSettings GetDatabaseSettings<T, K>(this IServiceCollection services, IConfiguration configuration)
       where T : class
       where K : class
    {
        DatabaseSettingItem[] itemDatabaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettingItem[]>();

        var result = new DatabaseSettings(itemDatabaseSettings.ToList());

        return result;
    }

    /// <summary>
    /// Configure multiple database settings by option design partern
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseSettingItem[] itemDatabaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettingItem[]>();

        services.Configure<DatabaseSettings>(options =>
        {
            options.ItemDatabaseSettings = itemDatabaseSettings.ToList();
        });

        return services;
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
        , DatabaseSettingItem defaultOption)
        where T : DbContext
    {
        if (defaultOption.DBProvider == DatabaseProviderConstants.SqlServer)
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(defaultOption.ConnectionString,
                        builder => builder.MigrationsAssembly(typeof(T).Assembly.FullName));
            });
        }

        return services;
    }

    /// <summary>
    /// Configure DbContext in service of the api 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection ConfigureDbContext<T>(this IServiceCollection services, IConfiguration configuration)
    where T : DbContext
    {
        var connectionName = "DefaultConnection";
        services.AddConfigurationSettings(configuration);
        var settings = services.GetDatabaseSettings<DatabaseSettingItem, DatabaseSettings>(configuration);

        ValidateSettings(settings);

        if (!settings.ItemDatabaseSettings.Any())
        {
            throw new Exception("Not found any database settings");
        }

        DatabaseSettingItem defaultOption = settings.ItemDatabaseSettings.FirstOrDefault(x => x.Name.Equals(connectionName));

        if (defaultOption == null || string.IsNullOrEmpty(defaultOption?.ConnectionString))
        {
            throw new Exception("Not found any database settings");
        }

        services.ConfigDatabaseProvider<T>(configuration, defaultOption);

        return services;
    }

    public static void ValidateSettings(DatabaseSettings settings)
    {
        var providers = settings.ItemDatabaseSettings.Select(x => x.DBProvider).Distinct().ToList();

        var allowedProvider = new List<string>()
        {
            DatabaseProviderConstants.SqlServer,
            DatabaseProviderConstants.Mongo,
            DatabaseProviderConstants.MySql,
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
