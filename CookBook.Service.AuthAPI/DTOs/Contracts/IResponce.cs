namespace CookBook.Service.AuthAPI.DTOs.Contracts
{
    
    public interface IResponce<T>
    {
        public T? Data { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
