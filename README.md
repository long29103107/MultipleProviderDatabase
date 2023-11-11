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

## Relational Database
### Add `appsettings.json` file for Sql Server provider

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

### Add `appsettings.json` file for Postgres provider

```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DBProvider": "postgres",
        "ConnectionString": "Server=localhost;Port=5433;Database=BasketDb;User Id=admin;Password=admin1234",
        "DatabaseName": "BasketDb"
      }
    ]
  }
```

### Add `appsettings.json` file for Sqlite provider

```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DBProvider": "sqlite",
        "ConnectionString": "Filename=Brand.db;",
        "DatabaseName": "BrandDb"
      }
    ]
  }
```

### Add `appsettings.json` file for MySql provider

```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DBProvider": "mysql",
        "ConnectionString": "Server=localhost;Port=3308;Database=CategoryDb;Uid=provider;Pwd=Passw0rd!;",
        "DatabaseName": "CategoryDb"
      }
    ]
  }
```

### Add `appsettings.json` file for ImMemory provider

```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DBProvider": "inmemory",
        "ConnectionString": ""
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

## NoSql Database
### Mongo provider
- Add Service
```
builder.Services.AddMongoService(builder.Configuration);
builder.Services.AddScoped<IMongoContext, RepositoryContext>();
```

- Add `appsettings.json` file
```
  "DatabaseSettings": {
    "DatabaseSettingItems": [
      {
        "Name": "DefaultConnection",
        "DatabaseName": "CustomerDb",
        "DBProvider": "mongodb",
        "ConnectionString": "mongodb://localhost:27017"
      }
    ]
  }
```