using CookBook.Service.AuthAPI.DTOs.Contracts;

namespace CookBook.Service.AuthAPI.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static Utility.ModelsAnnotations.ModelsAnnotations;

    public class RegisterDto : IRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; } = null!;

        [Required]
        [StringLength(AppUser.FirstNameMaxLength, MinimumLength = AppUser.FirstNameMinLength)]
        public string FirstName { get; init; } = null!;

        [Required]
        [StringLength(AppUser.LastNameMaxLength, MinimumLength = AppUser.LastNameMinLength)]
        public string LastName { get; init; } = null!;

        [Required]
        [StringLength(AppUser.PasswordMaxLength, MinimumLength = AppUser.PasswordMinLength)]
        public string Password { get; init; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; init; } = null!;
    }
}
