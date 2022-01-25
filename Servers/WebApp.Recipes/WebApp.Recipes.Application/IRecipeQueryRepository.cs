namespace WebApp.Recipes.Application
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApp.Common.Domain;
    using WebApp.Recipes.Application.Queries.GetInfo;
    using WebApp.Recipes.Application.Queries.All;
    using WebApp.Recipes.Application.Queries.GetMyRecipes;
    using WebApp.Recipes.Domain.Models;

    public interface IRecipeQueryRepository : IQueryRepository<Recipe>
    {
        public Task<RecipeInfoOutputModel> GetDetails(int id);
        public IEnumerable<RecipeOutputModel> GetAllRecipes();

        public Task<MyRecipesOutputModel> GetRecipesByUser(string userId);
    }
}
