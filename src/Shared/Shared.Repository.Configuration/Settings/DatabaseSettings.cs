namespace Shared.Repository.Configuration.Settings;

public class DatabaseSettings
{
    public DatabaseSettings()
    {
        
    }

    public DatabaseSettings(List<DatabaseSettingItem> values)
    {
        ItemDatabaseSettings = values;
    }

    public List<DatabaseSettingItem> ItemDatabaseSettings = new List<DatabaseSettingItem>();
}
public class DatabaseSettingItem
{
    public string Name { get; set; }
    public string DBProvider { get; set; }
    public string ConnectionString { get; set; }
}
