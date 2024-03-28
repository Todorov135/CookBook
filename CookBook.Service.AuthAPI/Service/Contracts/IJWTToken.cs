namespace CookBook.Service.AuthAPI.Service.Contracts
{
    using CookBook.Service.AuthAPI.Data.Models;

    public interface IJWTToken
    {
        string CreateToken(AppUser user);
    }
}
