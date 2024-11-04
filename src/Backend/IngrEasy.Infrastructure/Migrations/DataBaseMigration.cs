using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace IngrEasy.Infrastructure.Migrations;

public static class DataBaseMigration
{
    public static void DatabaseMigration(IServiceProvider service)
    {
     var runner = service.GetRequiredService<IMigrationRunner>();
     
     runner.ListMigrations();
     
     runner.MigrateUp();
    }   
}