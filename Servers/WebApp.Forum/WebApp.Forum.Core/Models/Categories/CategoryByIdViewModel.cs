namespace Recipes.ViewModels.Forum.Categories
{
    using System.Collections.Generic;
    using WebApp.Forum.Models.Posts;

    public class CategoryByIdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public ICollection<PostInCategoryViewModel> Posts { get; set; }

        public int PostsCount { get; set; }
    }
}
