﻿namespace Shared.Repository.Configuration.Constants;
public class DatabaseConstants
{
    public class Providers
    {
        public const string MySql = "mysql";
        public const string Mongo = "mongo";
        public const string SqlServer = "sqlserver";
        public const string Postgres = "postgres";
        public const string Sqlite = "sqlite";
        public const string InMemory = "inmemory";
    }
   
    public class Connections
    {
        public const string Default = "DefaultConnection";
    }
}
