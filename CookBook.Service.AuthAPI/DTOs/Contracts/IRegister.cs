namespace CookBook.Service.AuthAPI.DTOs.Contracts
{
    public interface IRegister
    {
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Password { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
