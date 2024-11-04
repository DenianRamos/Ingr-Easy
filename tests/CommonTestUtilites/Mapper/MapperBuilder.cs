using AutoMapper;
using IngrEasy.Application.Services.AutoMapper;

namespace CommonTestUtilites.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        return new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        }).CreateMapper();
    }
}