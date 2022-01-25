namespace WebApp.Recipes.Application.Queries.All
{
    using WebApp.Common.Application.Mapping;
    using WebApp.Recipes.Domain.Models;
    public class RecipeOutputModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Instructions { get; set; }
    }
}
