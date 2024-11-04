using FluentValidation;
using IngrEasy.Communication.Requests;
using IngrEasy.Exception.Resources.User;

namespace IngrEasy.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourcesErrorMessage.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourcesErrorMessage.EMAIL_EMPTY);
            
            When(user => !string.IsNullOrEmpty(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(ResourcesErrorMessage.EMAIL_INVALID);
            });

            RuleFor(user => user.Password).NotEmpty().WithMessage(ResourcesErrorMessage.PASSWORD_EMPTY);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourcesErrorMessage.PASSWORD_EMPTY);
        }
    }
}