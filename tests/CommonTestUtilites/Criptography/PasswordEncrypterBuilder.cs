using IngrEasy.Application.Criptography;

namespace CommonTestUtilites.Criptography;

public class PasswordEncrypterBuilder
{
    public static PasswordEncrypter Build() =>  new PasswordEncrypter("abc1234");

}