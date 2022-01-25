namespace WebApp.Forum.Domain.Factories
{
    using WebApp.Common.Domain;
    using WebApp.Forum.Domain.Models;
    public interface IPostFactory : IFactory<Post>
    {
        IPostFactory WithTitle(string title);
        IPostFactory WithUser(string userId);

        IPostFactory WithContent(string content);

        IPostFactory WithCategory(Category category);
    }
}
