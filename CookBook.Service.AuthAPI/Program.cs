
namespace CookBook.Service.AuthAPI
{
    using CookBook.Service.AuthAPI.Data;
    using CookBook.Service.AuthAPI.Data.Models;
    using CookBook.Service.AuthAPI.DTOs;
    using CookBook.Service.AuthAPI.Service;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using static ModelsAnnotations.ModelsAnnotations.AppUserAnnotation;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
            });

            builder.Services.AddIdentityCore<AppUser>(option =>
            {
                option.Password.RequiredLength = PasswordMinLength;
                option.Password.RequiredUniqueChars = 0;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IUserFactory, UserFactory>();
            builder.Services.AddScoped<IJWTToken, JWTToken>();
            builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));
            builder.Services.AddAuthentication(opt =>
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
                        ValidIssuer = "https://localhost:7034",
                        ValidAudience = "https://localhost:7034",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superSecretKey@345"))
                    };
                });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
