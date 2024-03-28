namespace CookBook.Service.AuthAPI.Data.Models
{
    using CookBook.Service.AuthAPI.Data.Models.Contracts;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static CookBook.Service.AuthAPI.ModelsAnnotations.ModelsAnnotations.AppUserAnnotation;

    public class AppUser : IdentityUser, IAppUser
    {
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
