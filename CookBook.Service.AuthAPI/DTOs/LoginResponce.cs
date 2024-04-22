namespace CookBook.Service.AuthAPI.DTOs
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;

    public class LoginResponce : ILoginResponce
    {
        private string _name;
        private string _token;
        public LoginResponce(string name, string token)
        {
            _name = name;
            _token = token;
        }
       
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Token 
        { 
            get
            {
                return _token;
            }
            set
            {
                _token = value;
            }
        } 
      
    }
}
