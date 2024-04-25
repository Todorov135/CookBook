namespace CookBook.Service.Recipe.Data.Models.Contracts
{
    public interface IRecipe : IBaseRecipe
    {
        public string PostedById { get; set; }
        public string Title { get; set; }
        public ICollection<RecipeProduct> RecipeсProductс { get; set; }
        public string Preparation { get; set; }
    }
}
