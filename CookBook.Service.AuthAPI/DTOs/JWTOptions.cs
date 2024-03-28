namespace CookBook.Service.AuthAPI.DTOs
{
    public class JWTOptions
    {
        public string SecurityKey { get;}
        public string Issuer { get;}
        public string Audience { get; }
    }
}
