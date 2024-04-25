namespace CookBook.Service.Recipe.Data.Models.Contracts
{
    public interface IRecipeProduct
    {
        public string RecipeId { get; set; } 
        public string ProductId { get; set; } 
        public float Quantity { get; set; }
        public byte Portions { get; set; }
    }
}
