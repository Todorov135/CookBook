namespace CookBook.Service.AuthAPI.Data.Models
{
    using CookBook.Service.AuthAPI.Data.Models.Contracts;
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static CookBook.Service.AuthAPI.Utility.ModelsAnnotations.ModelsAnnotations.AppUser;

    public class AppUser : IdentityUser, IAppUser
    {
        private string _firstName = null!;
        private string _lastName = null!;

        [StringLength(FirstNameMaxLength)]
        public string FirstName { get => _firstName; set => _firstName = value; }

        [StringLength(LastNameMaxLength)]
        public string LastName { get => _lastName; set => _lastName = value; }

        public void SetUserInfo(string firstName, string lastName, string email)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            base.Email = email;
            base.UserName = email;
        }
    }
}
