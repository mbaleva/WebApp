namespace WebApp.Recipes.Application.Queries.GetAllCategories
{
    using System;
    using WebApp.Common.Application.Mapping;
    using WebApp.Recipes.Domain.Models;

    public class GetAllCategoriesOutputModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
