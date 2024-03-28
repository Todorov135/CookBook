namespace CookBook.Service.AuthAPI.ModelsAnnotations
{
    public static class ModelsAnnotations
    {
        public static class AppUserAnnotation
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 50;

            public const int PasswordMinLength = 6;
        }
    }
}
