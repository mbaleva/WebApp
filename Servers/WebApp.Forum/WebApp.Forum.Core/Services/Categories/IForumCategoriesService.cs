namespace WebApp.Forum.Services.Categories
{
    using Recipes.ViewModels.Forum.Categories;
    using System.Collections.Generic;

    public interface IForumCategoriesService
    {
        List<OneCategoryViewModel> GetAllCategories();

        CategoryByIdViewModel GetInfoForCategoryById(int id);

        Dictionary<string, string> GetAllCategoriesAsKeyValuePairs();
    }
}
