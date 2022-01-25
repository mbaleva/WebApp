namespace Recipes.Services.ForumSystem.Comments
{
    using Recipes.ViewModels.Forum.Comments;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Forum.Data;
    using WebApp.Forum.Data.Models;
    using WebApp.Forum.Services.Comments;

    public class CommentsService : ICommentsService
    {
        private ApplicationDbContext dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateCommentAsync(CreateCommentInputModel model, string userId)
        {
            Comment comment = new Comment
            { 
                Content = model.Content,
                CreatedOn = DateTime.Now,
                PostId = model.PostId,
                UserId = userId,
                ParentCommentId = model.ParentId,
            };
            await this.dbContext.Comments.AddAsync(comment);
            await this.dbContext.SaveChangesAsync();
        }

        public bool IsInSamePost(int postId, int? commentId)
        {
            var commentPostId = this.dbContext.Comments
                .Where(x => x.Id == commentId)
                .Select(x => x.PostId)
                .FirstOrDefault();

            return postId == commentPostId;
        }
    }
}
