namespace CookBook.Service.AuthAPI.DTOs.Contracts
{
    public interface ILoginResponce
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
