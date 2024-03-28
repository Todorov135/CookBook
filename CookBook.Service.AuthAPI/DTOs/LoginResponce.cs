namespace CookBook.Service.AuthAPI.DTOs
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;

    public class LoginResponce : ILoginResponce
    {
        private string _name;
        private string _token;
        private string _email;
        private string _phoneNumber;
        public LoginResponce(string name, string token, string email)
        {
            _name = name;
            _token = token;
            _email = email;
        }
        public LoginResponce(string name, string token, string email, string phoneNumber) : this(name, token, email)
        {
            _phoneNumber = phoneNumber;
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
        public string Email 
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        } 

        public string PhoneNumber 
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _phoneNumber = "No phone number added";
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }
    }
}
