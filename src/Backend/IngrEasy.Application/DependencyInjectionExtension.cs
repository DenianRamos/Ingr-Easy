using IngrEasy.Application.Criptography;
using IngrEasy.Application.Services.AutoMapper;
using IngrEasy.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IngrEasy.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddPasswordEncrypter(services,configuration);
        AddAutomapper(services);
        AddUseCase(services);
        
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
    
    private static void AddAutomapper(IServiceCollection services)
    {

        services.AddScoped(opt => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());
    }

    private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuratio)
    {
        var keyAdditional = configuratio.GetValue<string>("Settings:Password:AdditionalKey");
        services.AddScoped(opt => new PasswordEncrypter(keyAdditional!));
    }
}