using System.Reflection;
using FluentMigrator.Runner;
using IngrEasy.Domain.Repositories;
using IngrEasy.Domain.Repositories.User;
using IngrEasy.Infrastructure.DataAcess;
using IngrEasy.Infrastructure.DataAcess.Repositories;
using IngrEasy.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IngrEasy.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            AddDbContext(services, configuration);
            AddRepositories(services);

            AddFluentMigration(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IngrEasyDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddFluentMigration(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options.AddMySql5()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.Load("IngrEasy.Infrastructure")).For.All();
            });
        }
    }
}