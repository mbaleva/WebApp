namespace WebApp.Forum.Domain.Factories
{
    using WebApp.Forum.Domain.Models;
    public class PostFactory : IPostFactory
    {
        private Category category;
        private string title;
        private string content;
        private string userId;

        public IPostFactory WithCategory(Category category)
        {
            this.category = category;
            return this;
        }

        public IPostFactory WithContent(string content)
        {
            this.content = content;
            return this;
        }

        public IPostFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public IPostFactory WithUser(string userId)
        {
            this.userId = userId;
            return this;
        }

        public Post Build() =>
            new Post(
                this.title,
                this.userId,
                this.content,
                this.category
                );
    }
}
