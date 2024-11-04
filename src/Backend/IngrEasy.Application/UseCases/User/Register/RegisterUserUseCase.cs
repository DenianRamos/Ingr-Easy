
using AutoMapper;
using FluentValidation.Results;
using IngrEasy.Application.Criptography;
using IngrEasy.Application.Services.AutoMapper;
using IngrEasy.Communication.Requests;
using IngrEasy.Communication.Response;
using IngrEasy.Domain.Repositories;
using IngrEasy.Domain.Repositories.User;
using IngrEasy.Exception.ExceptionBase;
using IngrEasy.Exception.Resources.User;

namespace IngrEasy.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly PasswordEncrypter _passwordEncrypter;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserUseCase(IUserReadOnlyRepository readOnlyRepository, IUserWriteOnlyRepository writeOnlyRepository, IMapper mapper, PasswordEncrypter passwordEncrypter, IUnitOfWork unitOfWork)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _mapper = mapper;
        _passwordEncrypter = passwordEncrypter;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);
        var user = _mapper.Map<Domain.Entities.User>(request);

        user.Password = _passwordEncrypter.Encrypt(request.Password);
        
       await _writeOnlyRepository.Add(user);

       await _unitOfWork.Commit();
       
     

     return new ResponseRegisterUserJson
     {
         Name = user.Name
     };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        
        var validator = new  RegisterUserValidator();

       var result = validator.Validate(request);
       var emailExist =await _readOnlyRepository.ExistActiveUserWithEmail(request.Email);
       
       if (emailExist)
           result.Errors.Add(new ValidationFailure(string.Empty, ResourcesErrorMessage.EMAIL_ALREADY_EXIST));
           
           
           
       if (result.IsValid is false)
       {
           var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
           throw new ErrorOnValidationException(errorMessages);
       }
        


    }
}