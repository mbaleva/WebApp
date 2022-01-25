namespace WebApp.Forum.Services.Posts
{
    using Recipes.ViewModels.Forum.Comments;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Forum.Data;
    using WebApp.Forum.Data.Models;
    using WebApp.Forum.Models.Posts;

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext dbContext;

        public PostsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddPostAsync(CreatePostInputModel model, string userId)
        {
            var post = new Post
            {
                CategoryId = model.CategoryId,
                Content = model.Content,
                CreatedOn = DateTime.UtcNow,
                Title = model.Title,
                UserId = userId,
            };
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post.Id;
        }

        public List<OnePostViewModel> All(int page, int itemsPerPage)
        {
            return dbContext.Posts
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new OnePostViewModel
                {
                    Content = x.Content,
                    CountLikes = x.Votes.Sum(x => x.Value),
                    Id = x.Id,
                    Name = x.Title,
                })
                .ToList();
        }

        public PostByIdViewModel GetPostById(int id)
        {
            return dbContext.Posts.Where(x => x.Id == id)
                .Select(x => new PostByIdViewModel
                {
                    CategoryName = x.Category.Name,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    Id = x.Id,
                    Title = x.Title,
                    CountLikes = x.Votes.Sum(x => x.Value),
                    Comments = x.Comments.Select(x =>
                        new CommentInPostViewModel
                        {
                            Content = x.Content,
                            CreatedOn = x.CreatedOn,
                            Id = x.Id,
                            ParentId = x.ParentCommentId,
                            CountLikes = x.Votes.Sum(x => x.Value),
                        }).ToList(),
                }).FirstOrDefault();
        }

        public List<OnePostViewModel> SearchPost(string term, int categoryId, int page, int itemsPerPage)
        {
            if (categoryId == -1 || categoryId == 0)
            {
                return dbContext.Posts
                    .Where(x => x.Title.Contains(term))
                    .OrderByDescending(x => x.CreatedOn)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .Select(x => new OnePostViewModel
                    {
                        Content = x.Content,
                        Name = x.Title,
                        Id = x.Id,
                        CountLikes = x.Votes.Sum(x => x.Value),
                    })
                    .ToList();
            }
            return dbContext.Posts
                    .Where(x => x.Title.Contains(term) && x.CategoryId == categoryId)
                    .OrderByDescending(x => x.CreatedOn)
                    .Select(x => new OnePostViewModel
                    {
                        Content = x.Content,
                        Name = x.Title,
                        Id = x.Id,
                        CountLikes = x.Votes.Sum(x => x.Value),
                    })
                    .ToList();
        }

        public int GetCount()
        {
            return dbContext.Posts.Count();
        }

        public int GetCountForSearch(string term, int categoryId)
        {

            if (categoryId == -1 || categoryId == 0)
            {
                return dbContext.Posts
                    .Where(x => x.Title.Contains(term))
                    .Count();
            }
            return dbContext.Posts
                    .Where(x => x.Title.Contains(term) && x.CategoryId == categoryId)
                    .Count();
        }
    }
}
