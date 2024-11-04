using IngrEasy.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilites.Repositories;

public class UserReadOnlyRepositoryBuilder
{

    private readonly Mock<IUserReadOnlyRepository> _repository;

    public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();

    public  IUserReadOnlyRepository Build() =>  _repository.Object;


    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(x => x.ExistActiveUserWithEmail(It.Is<string>(e => e == email)))
            .ReturnsAsync(true);
    }


}