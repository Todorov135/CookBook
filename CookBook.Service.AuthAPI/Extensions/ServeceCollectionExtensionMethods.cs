namespace CookBook.Service.AuthAPI.Extensions
{
    using CookBook.Service.AuthAPI.Data;
    using CookBook.Service.AuthAPI.Data.Models;
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.Service;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class ServeceCollectionExtensionMethods
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IJWTToken, JWTToken>();

            return services;
        }

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtOptions = config.GetSection("JWTOptions");

            services.Configure<JWTOptions>(jwtOptions);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.GetValue<string>("Issuer"),
                        ValidAudience = jwtOptions.GetValue<string>("Audience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.GetValue<string>("SecurityKey")))
                    };
                });

            return services;
        }

        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("DefaultString"));
            });

            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
