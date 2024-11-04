using IngrEasy.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilites.Repositories;

public class UserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        
        return mock.Object;
    }
}