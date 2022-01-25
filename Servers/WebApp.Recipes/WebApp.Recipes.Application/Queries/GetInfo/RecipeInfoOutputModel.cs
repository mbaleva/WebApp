namespace WebApp.Recipes.Application.Queries.GetInfo
{
    using System.Collections.Generic;
    using WebApp.Common.Application.Mapping;
    using WebApp.Recipes.Domain.Models;
    using AutoMapper;

    public class RecipeInfoOutputModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }

        public int PortionsCount { get; set; }
        public Category Category { get; private set; }
        public string ImageUrl { get; set; }
        public ICollection<IngredientToRecipe> Ingredients { get; set; }

    }
}
