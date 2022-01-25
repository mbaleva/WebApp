namespace WebApp.Forum.Application
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApp.Common.Application.Contracts;
    using WebApp.Forum.Application.Queries.All;
    using WebApp.Forum.Application.Queries.ById;
    using WebApp.Forum.Domain.Models;

    public interface IPostQueryRepository : IQueryRepository<Post>
    {
        IEnumerable<PostInCollectionModel> AllPosts();
        Task<PostByIdOutputModel> ById(int id);
    }
}
