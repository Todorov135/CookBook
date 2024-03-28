namespace CookBook.Service.AuthAPI.Service.Factory.Interfaces
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;

    public interface IUserFactory
    {
        public ILoginResponce CreateLoginResponce(string name, string token, string email);
        public ILoginResponce CreateLoginResponce(string name, string token, string email, string phoneNumber);
    }
}
