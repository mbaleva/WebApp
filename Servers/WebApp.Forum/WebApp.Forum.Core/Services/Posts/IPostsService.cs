namespace WebApp.Forum.Services.Posts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using WebApp.Forum.Models.Posts;

    public interface IPostsService
    {
        PostByIdViewModel GetPostById(int id);

        Task<int> AddPostAsync(CreatePostInputModel model, string userId);

        List<OnePostViewModel> SearchPost(string term, int categoryId, int page, int itemsPerPage);

        List<OnePostViewModel> All(int page, int itemsPerPage);

        int GetCount();

        int GetCountForSearch(string term, int categoryId);
    }
}
