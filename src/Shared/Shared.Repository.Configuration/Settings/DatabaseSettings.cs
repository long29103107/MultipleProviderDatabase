namespace Shared.Repository.Configuration.Settings;

public class DatabaseSettings
{

    public List<DatabaseSettingItem> DatabaseSettingItems = new List<DatabaseSettingItem>();
    public DatabaseSettings()
    {
        
    }

    public DatabaseSettings(List<DatabaseSettingItem> values)
    {
        DatabaseSettingItems = values;
    }
}
public class DatabaseSettingItem
{
    public string Name { get; set; }
    public string DatabaseName { get; set; }
    public string DBProvider { get; set; }
    public string ConnectionString { get; set; }
}
