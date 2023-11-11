# Project `multiple provider` using multiple provider

## Provider support
```
public class Providers
{
    public const string MySql = "mysql";
    public const string Mongo = "mongo";
    public const string SqlServer = "sqlserver";
    public const string Postgres = "postgres";
    public const string Sqlite = "sqlite";
    public const string InMemory = "inmemory";
}
```

## Sql Server
### Add `appsettings.json`

```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DBProvider": "sqlserver",
        "ConnectionString": "Server=localhost,1435;Database=ProductDb;User=sa;Password=Passw0rd!;MultipleActiveResultSets=True;TrustServerCertificate=true"
      }
    ]
  }
```

### Add `DbContext`

- Import library
```
using Shared.Repository.Configuration.Extensions;
```

- Add `Dbcontext`
```
builder.Services.ConfigureDbContext<RepositoryContext>(builder.Configuration);
```



