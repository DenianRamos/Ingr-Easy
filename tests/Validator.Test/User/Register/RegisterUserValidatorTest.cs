using CommonTestUtilites.Requests;
using FluentAssertions;
using IngrEasy.Application.UseCases.User.Register;
using IngrEasy.Exception.Resources.User;

namespace Validator.Test.User.Register;

public class RegisterUserValidatorTest
{
    [Fact]
    public void Sucess()
    {
       var validator = new RegisterUserValidator();

       var request = RequestRegisterUserJsonBuilder.Build();
       var result = validator.Validate(request);
        
       result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void Error_Name_Empty()
    {
        var validator = new RegisterUserValidator();

        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessage.NAME_EMPTY));
    }
    
    [Fact]
    public void Error_Email_Empty()
    {
        var validator = new RegisterUserValidator();

        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = string.Empty;
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessage.EMAIL_EMPTY));
    }
    
    [Fact]
    public void Error_Email_Invalid()
    {
        var validator = new RegisterUserValidator();

        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "email.com";
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessage.EMAIL_INVALID));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    
    public void Error_Password_Invalid(int passwordLenght)
    {
        var validator = new RegisterUserValidator();

        var request = RequestRegisterUserJsonBuilder.Build(passwordLenght);
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
            .And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessage.PASSWORD_EMPTY));
    }
    
}