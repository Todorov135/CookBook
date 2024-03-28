namespace CookBook.Service.AuthAPI.Service.Factory
{
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;

    public class UserFactory : IUserFactory
    {
        public ILoginResponce CreateLoginResponce(string name, string token)
        {
            return new LoginResponce(name, token);
        }
    }
}
