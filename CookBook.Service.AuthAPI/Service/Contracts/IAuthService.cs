namespace CookBook.Service.AuthAPI.Service.Contracts
{
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.DTOs.Contracts;

    public interface IAuthService
    {
        public Task<Responce<ILoginResponce>> Login(ILogin loginDto);
        public Task<bool> Register(ILogin loginDto);
    }
}
