namespace CookBook.Service.AuthAPI.DTOs
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static CookBook.Service.AuthAPI.Utility.ModelsAnnotations.ModelsAnnotations.AppUser;

    public class LoginDto : ILogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}
