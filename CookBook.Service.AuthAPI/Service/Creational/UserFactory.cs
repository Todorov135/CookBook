namespace CookBook.Service.AuthAPI.Service.Factory
{
    using CookBook.Service.AuthAPI.Data.Models.Contracts;
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;

    public class UserFactory : IUserFactory
    {
        public ILoginResponce CreateLoginResponce(string name, string token)
        {
            return new LoginResponce(name, token);
        }

        public IAppUser? CreateUser(Type type)
        {
            if (!type.IsClass || type.IsAbstract || type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new ArgumentException("Type must be a concrete class with a parameterless constructor.");
            }

            IAppUser? instance = (IAppUser?)Activator.CreateInstance(type);

            return instance;
        }

    }
}
