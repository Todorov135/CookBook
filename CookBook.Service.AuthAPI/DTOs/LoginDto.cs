namespace CookBook.Service.AuthAPI.DTOs
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static ModelsAnnotations.ModelsAnnotations.AppUserAnnotation;

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
