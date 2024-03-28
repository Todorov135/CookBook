
namespace CookBook.Service.AuthAPI
{
    using CookBook.Service.AuthAPI.Data;
    using CookBook.Service.AuthAPI.Data.Models;
    using CookBook.Service.AuthAPI.Service;
    using CookBook.Service.AuthAPI.Service.Contracts;
    using CookBook.Service.AuthAPI.Service.Factory;
    using CookBook.Service.AuthAPI.Service.Factory.Interfaces;
    using Microsoft.EntityFrameworkCore;
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
