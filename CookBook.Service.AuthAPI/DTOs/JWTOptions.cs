namespace CookBook.Service.AuthAPI.DTOs
{
    public class JWTOptions
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
