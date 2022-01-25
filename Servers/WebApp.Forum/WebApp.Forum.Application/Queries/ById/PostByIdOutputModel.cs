namespace WebApp.Forum.Application.Queries.ById
{
    using System;
    using WebApp.Common.Application.Mapping;
    using WebApp.Forum.Domain.Models;

    public class PostByIdOutputModel : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
    }
}
