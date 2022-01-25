namespace Recipes.ViewModels.Forum.Index
{
    using global::Recipes.ViewModels.Forum.Categories;
    using System.Collections.Generic;
    using WebApp.Forum.Models;

    public class IndexViewModel : PaginationViewModel
    {
        public List<OneCategoryViewModel> Categories { get; set; }

        public Dictionary<string, string> CategoriesAsKeyValues { get; set; }
    }
}
