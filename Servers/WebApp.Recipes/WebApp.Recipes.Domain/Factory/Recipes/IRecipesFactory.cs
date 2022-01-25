namespace WebApp.Recipes.Domain.Factory.Recipes
{
    using Models;
    using WebApp.Common.Domain;

    public interface IRecipesFactory : IFactory<Recipe>
    {
        IRecipesFactory WithName(string name);
        IRecipesFactory WithInstructions(string instructions);
        IRecipesFactory WithPrepTime(int time);
        IRecipesFactory WithCookingTime(int time);
        IRecipesFactory WithPortionsCount(int portionsCount);
        IRecipesFactory WithCategory(Category category);
        IRecipesFactory WithUser(string userId);
        IRecipesFactory WithImage(string imageUrl);
        IRecipesFactory AddIngredient(string ingredient);
        IRecipesFactory AddVote(Recipe recipe, string user, double value);

    }
}
