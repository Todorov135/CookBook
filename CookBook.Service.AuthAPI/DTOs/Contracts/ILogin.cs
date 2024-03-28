namespace CookBook.Service.AuthAPI.DTOs.Contracts
{
    public interface ILogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
