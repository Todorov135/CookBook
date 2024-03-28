namespace CookBook.Service.AuthAPI.Service
{
    using CookBook.Service.AuthAPI.Data;
    using CookBook.Service.AuthAPI.Data.Models;
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using static CookBook.Service.AuthAPI.Utility.ErrorMessage;

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserFactory _userFactory;
        private readonly IJWTToken _jwtToken;
                
        public AuthService(AppDbContext db, UserManager<AppUser> userManager, IUserFactory userFactory, IJWTToken jwtToken)
        {
            _db = db;
            _userManager = userManager;
            _userFactory = userFactory;
            _jwtToken = jwtToken;
        }
        public async Task<Responce<ILoginResponce>> Login(ILogin loginDto)
        {
            Responce<ILoginResponce> responce = Responce<ILoginResponce>.CreateInstance();

            try
            {
                var user = await _db.Users.FirstAsync(u => u.Email == loginDto.Email);
                var isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (!isValidUser)
                {
                    responce.Errors.Add(InvalidPassword);

                    return responce;
                }
                var token = _jwtToken.CreateToken(user);
                responce.Data = _userFactory.CreateLoginResponce(user.FirstName, token);
            }
            catch (Exception m)
            {
                responce.Errors.Add(m.Message);                
            }

            return responce;
        }
    }
}
