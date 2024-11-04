using AutoMapper;
using IngrEasy.Communication.Requests;
using IngrEasy.Domain.Entities;

namespace IngrEasy.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, User>().ForMember(dest => dest.Password, opt => opt.Ignore());
    }
}