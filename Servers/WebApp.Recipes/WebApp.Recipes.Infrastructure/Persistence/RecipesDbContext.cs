namespace WebApp.Recipes.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using WebApp.Recipes.Domain.Models;

    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {

        }
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            :base(options)
        {
        
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IngredientToRecipe> RecipeIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
