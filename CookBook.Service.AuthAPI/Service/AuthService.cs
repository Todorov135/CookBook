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
    using static CookBook.Service.AuthAPI.Utility.Error.ErrorMessage;

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
            var responce = Responce<ILoginResponce>.CreateInstance();

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

        public async Task<Responce<bool>> Register(IRegister registerDto)
        {
            var responce = Responce<bool>.CreateInstance();
            try
            {
                var user = (AppUser?)_userFactory.CreateUser(typeof(AppUser));

                user.SetUserInfo(registerDto.FirstName, registerDto.LastName, registerDto.Email);

                var checkForExistingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (checkForExistingUser != null)
                {
                    responce.Errors.Add(string.Format(ЕxistingUser, registerDto.Email));

                    return responce;
                }

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                   responce.AddMultipleErrors(result.Errors.Select(x => x.Description));

                    return responce;
                }

                return responce;
            }
            catch (Exception e)
            {
                responce.Errors.Add(e.Message);

                return responce;
            }
        }
    }
}
