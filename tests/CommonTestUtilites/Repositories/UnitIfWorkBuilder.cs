using IngrEasy.Domain.Repositories;
using Moq;

namespace CommonTestUtilites.Repositories;

public class UnitIfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock =  new Mock<IUnitOfWork>();
        
        return mock.Object;
    } 
}