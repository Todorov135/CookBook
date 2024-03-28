namespace CookBook.Service.AuthAPI.DTOs.Contracts
{
    public interface ILoginResponce
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
