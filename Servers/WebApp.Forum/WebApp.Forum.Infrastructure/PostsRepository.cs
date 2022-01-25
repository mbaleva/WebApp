namespace WebApp.Forum.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Common.Application.Mapping;
    using WebApp.Common.Infrastructure.Persistence;
    using WebApp.Forum.Application;
    using WebApp.Forum.Application.Queries.All;
    using WebApp.Forum.Application.Queries.ById;
    using WebApp.Forum.Domain;
    using WebApp.Forum.Domain.Models;
    using WebApp.Forum.Infrastructure.Persistence;

    internal class PostsRepository : DataRepository<ForumDbContext, Post>,
        IDomainPostRepository, IPostQueryRepository
    {
        private ForumDbContext context;

        public PostsRepository(ForumDbContext db) : base(db)
        {
        }

        public IEnumerable<PostInCollectionModel> AllPosts() => this.Data
                .Posts
                .Where(x => x.Id >= 0)
                .To<PostInCollectionModel>()
                .ToList();

        public async Task<PostByIdOutputModel> ById(int id) => this.Data
                .Posts
                .Where(x => x.Id == id)
                .To<PostByIdOutputModel>()
                .FirstOrDefault();

        public Task Delete(int id)
        {
            var entity = this.Data.Posts.Where(x => x.Id == id).FirstOrDefault();
            this.Data.Posts.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Post> GetById(int id) => this.Data.Posts.Where(x => x.Id == id).FirstOrDefault();

        public Category GetCategory(int categoryId)
        {
            return this.Data.Categories.Where(x => x.Id == categoryId)
                .FirstOrDefault();
        }
    }
}
