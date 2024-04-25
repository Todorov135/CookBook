namespace CookBook.Service.Recipe.Data.Models.Contracts
{
    public interface IBaseRecipe
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsRemoved { get; set; }

    }
}
