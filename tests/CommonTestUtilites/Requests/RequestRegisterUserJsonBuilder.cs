using Bogus;
using IngrEasy.Communication.Requests;

namespace CommonTestUtilites.Requests;

public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build(int passwordLenght = 6)
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Name, (faker) => faker.Person.FirstName)
            .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
            .RuleFor(user => user.Password, (faker) => faker.Internet.Password(passwordLenght));


    }
}