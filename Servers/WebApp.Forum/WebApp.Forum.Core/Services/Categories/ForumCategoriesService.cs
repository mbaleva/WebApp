namespace WebApp.Forum.Services.Categories
{
    using Recipes.ViewModels.Forum.Categories;
    using System.Collections.Generic;
    using System.Linq;
    using WebApp.Forum.Data;
    using WebApp.Forum.Models.Posts;

    public class ForumCategoriesService : IForumCategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public ForumCategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<OneCategoryViewModel> GetAllCategories()
        {
            return dbContext.Categories
                .Select(x => new OneCategoryViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    ImageURL = x.ImageURL,
                    Name = x.Name,
                    PostsCount = x.Posts.Count,
                }).ToList();
        }

        public CategoryByIdViewModel GetInfoForCategoryById(int id)
        {
            return dbContext.Categories.Where(x => x.Id == id)
                .Select(x => new CategoryByIdViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    Name = x.Name,
                    PostsCount = x.Posts.Count,
                    Posts = x.Posts.Select(x => new PostInCategoryViewModel
                    {
                        CommentsCount = x.Comments.Count,
                        Content = x.Content.Length > 100 ? x.Content.Substring(0, 100) + "..." : x.Content,
                        CreatedOn = x.CreatedOn,
                        Id = x.Id,
                        Title = x.Title,
                    }).ToList(),
                }).FirstOrDefault();
        }
        public Dictionary<string, string> GetAllCategoriesAsKeyValuePairs()
        {
            var result = new Dictionary<string, string>();

            foreach (var item in dbContext.Categories)
            {
                result.Add(item.Id.ToString(), item.Name);
            }
            return result;
        }
    }
}
