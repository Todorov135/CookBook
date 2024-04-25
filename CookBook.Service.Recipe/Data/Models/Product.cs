namespace CookBook.Service.Recipe.Data.Models
{
    using CookBook.Service.Recipe.Data.Models.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static Utility.ModelsAnnotations.ModelsAnnotations;

    public class Product : IProduct
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(ProductAnnotation.NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? Image { get; set; }
    }
}