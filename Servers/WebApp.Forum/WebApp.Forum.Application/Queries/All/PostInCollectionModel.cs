namespace WebApp.Forum.Application.Queries.All
{
    using WebApp.Common.Application.Mapping;
    using WebApp.Forum.Domain.Models;
    public class PostInCollectionModel : IMapFrom<Post>
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
