using FluentMigrator;

namespace IngrEasy.Infrastructure.Migrations.Versions
{
    [Migration(1, "Create User Table")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTableWithDefaults("Users")
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Email").AsString(50).NotNullable();
        }
    }
}