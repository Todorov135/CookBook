namespace CookBook.Service.Recipe.Data.Models
{
    using CookBook.Service.Recipe.Data.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Recipe : IRecipe
    {
        private Recipe()
        {
            this.RecipeсProductс = new HashSet<RecipeProduct>();
        }

        [Key]
        public string Id { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsRemoved { get; set; }

        [Required]
        public string PostedById { get; set; } = null!;
        public string Title { get; set; } = null!;
        public virtual ICollection<RecipeProduct> RecipeсProductс { get; set ; }
        public string Preparation { get; set; } = null!;
    }
}
