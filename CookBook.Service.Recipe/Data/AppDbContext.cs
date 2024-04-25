namespace CookBook.Service.Recipe.Data
{
    using CookBook.Service.Recipe.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; init; }
        public DbSet<Recipe> Recipes { get; init; }
        public DbSet<RecipeProduct> RecipesProducts { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeProduct>().HasKey(k => new { k.RecipeId, k.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
