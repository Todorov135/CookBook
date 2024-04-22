namespace CookBook.Service.AuthAPI.DTOs
{
    using CookBook.Service.AuthAPI.DTOs.Contracts;
    using System.Collections.Generic;

    public class Responce<T> : IResponce<T>
    {
        private Responce()
        {
            this.Errors = new List<string>();
        }

        public T? Data { get; set ; }
        public bool IsSuccess => !this.Errors.Any();
        public ICollection<string> Errors { get; set ; }

        public static Responce<T> CreateInstance()
        {
            return new Responce<T>();
        }
        public void AddMultipleErrors(IEnumerable<string> errors)
        {
            foreach (string error in errors)
            {
                this.Errors.Add(error);
            }
        }
    }
}
