namespace CookBook.Service.Recipe.Data.Models
{
    using CookBook.Service.Recipe.Data.Models.Contracts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeProduct : IRecipeProduct
    {
        [Key]
        [ForeignKey(nameof(Recipe))]
        public string RecipeId { get; set; } = null!;
        public Recipe Recipe { get; set; } = null!;

        [Key]
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public float Quantity { get; set; }
                
        public byte Portions { get; set; }
    }
}
