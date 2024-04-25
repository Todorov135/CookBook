namespace CookBook.Service.AuthAPI.Utility.ModelsAnnotations
{
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
        }
    }
}
