namespace CookBook.Service.AuthAPI.Data
{
    using CookBook.Service.AuthAPI.Data.Models;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography;

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            string password = "Admin123!";
            var hasher = new PasswordHasher<AppUser>();
            var admin = new AppUser()
            {
                Id = "027c4f2c-9189-480e-9d2c-a5ba0bcf24e1",
                FirstName = "Admin",
                LastName = "LastAdminName",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@admin.com".ToUpper()
            };
            admin.PasswordHash = hasher.HashPassword(admin, password);

            builder.Entity<AppUser>().HasData(admin);

            base.OnModelCreating(builder);
        }
    }
}
