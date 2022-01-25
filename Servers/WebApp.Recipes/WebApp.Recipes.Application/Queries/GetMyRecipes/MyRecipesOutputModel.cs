namespace WebApp.Recipes.Application.Queries.GetMyRecipes
{
    using System.Collections.Generic;
    using WebApp.Recipes.Application.Queries.All;

    public class MyRecipesOutputModel
    {
        public IEnumerable<RecipeOutputModel> MyRecipes { get; set; }
    }
}
