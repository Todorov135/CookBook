namespace CookBook.Service.AuthAPI.Service.Factory.Interfaces
{
    using CookBook.Service.AuthAPI.Data.Models.Contracts;
    using CookBook.Service.AuthAPI.DTOs.Contracts;

    public interface IUserFactory
    {
        public ILoginResponce CreateLoginResponce(string name, string token);
        public IAppUser? CreateUser(Type type);
    }
}
