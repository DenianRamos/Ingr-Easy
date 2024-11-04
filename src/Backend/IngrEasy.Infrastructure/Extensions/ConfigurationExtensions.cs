using Microsoft.Extensions.Configuration;

namespace IngrEasy.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        
        public static bool IsUnitTestEnviroment(this IConfiguration configuration)
        {
          return configuration.GetValue<bool>("InMemoryTest");
        }
        public static string ConnectionString(this IConfiguration configuration, string name = "DefaultConnection")
        {
            return configuration.GetConnectionString(name)!;
        }
    }
}