namespace CookBook.Service.AuthAPI.Utility.ModelsAnnotations
{
    using System.Dynamic;

    public static class ModelsAnnotations
    {
        public static class AppUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 50;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 16;
            public const string PasswordRegex = @"^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";

        }
    }
}
