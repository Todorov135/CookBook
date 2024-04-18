namespace CookBook.Service.AuthAPI.Service
{
    using CookBook.Service.AuthAPI.Data.Models;
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JWTToken : IJWTToken
    {
        private readonly JWTOptions _options;

        public JWTToken(IOptions<JWTOptions> options)
        {
            _options = options.Value;
        }

        public string CreateToken(AppUser user)
        {
            
            var claimList = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claimList,
                expires: DateTime.Now.AddHours(48),
                signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;

        }
    }
}
