namespace WebApp.Forum.Services.Comments
{
    using Recipes.ViewModels.Forum.Comments;
    using System.Threading.Tasks;
    public interface ICommentsService
    {
        Task CreateCommentAsync(CreateCommentInputModel model, string userId);

        bool IsInSamePost(int postId, int? commentId);
    }
}
