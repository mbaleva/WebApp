namespace WebApp.Recipes.Domain.Models
{
    using WebApp.Common.Domain.Models;
    public class IngredientToRecipe : Entity<int>
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string Quantity { get; set; }
    }
}
