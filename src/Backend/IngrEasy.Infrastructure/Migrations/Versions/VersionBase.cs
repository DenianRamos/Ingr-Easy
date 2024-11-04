using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace IngrEasy.Infrastructure.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        protected ICreateTableColumnOptionOrWithColumnSyntax CreateTableWithDefaults(string table)
        {
            return Create.Table(table)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable();
        }
    }
}