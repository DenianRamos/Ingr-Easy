using CommonTestUtilites.Criptography;
using CommonTestUtilites.Mapper;
using CommonTestUtilites.Repositories;
using CommonTestUtilites.Requests;
using FluentAssertions;
using IngrEasy.Application.UseCases.User.Register;
using IngrEasy.Communication.Requests;
using IngrEasy.Exception.ExceptionBase;
using IngrEasy.Exception.Resources.User;

namespace UseCases.Test.User.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase();

     var result = await useCase.Execute(request);

     result.Should().NotBeNull();
     result.Name.Should().Be(request.Name);
    }

    
    [Fact]
    public async Task Error_Email_Already_Exist()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email);
        
        Func<Task> act = async () => await useCase.Execute(request);

        (await act.Should().ThrowAsync<ErrorOnValidationException>()).Where(e => e.Errors.Count == 1
        && e.Errors.Contains(ResourcesErrorMessage.EMAIL_ALREADY_EXIST));
    }
    
    [Fact]
    public async Task Error_Name_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        var useCase = CreateUseCase();
        
        Func<Task> act = async () => await useCase.Execute(request);

        (await act.Should().ThrowAsync<ErrorOnValidationException>()).Where(e => e.Errors.Count == 1
            && e.Errors.Contains(ResourcesErrorMessage.NAME_EMPTY));
    }


    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var mapper = MapperBuilder.Build();
        var passwordEncrypter = PasswordEncrypterBuilder.Build();
        var writeOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
        var unitOfWork = UnitIfWorkBuilder.Build();
        var readRepositryBuilder = new UserReadOnlyRepositoryBuilder();
        if (string.IsNullOrEmpty(email) == false)
            readRepositryBuilder.ExistActiveUserWithEmail(email);
            
        return new RegisterUserUseCase(readRepositryBuilder.Build(), writeOnlyRepository,mapper,passwordEncrypter, unitOfWork);

    }
}