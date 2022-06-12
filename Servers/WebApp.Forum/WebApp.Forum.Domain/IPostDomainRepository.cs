namespace WebApp.Forum.Domain
{
    using System.Threading.Tasks;
    using WebApp.Common.Domain;
    using WebApp.Forum.Domain.Models;

    public interface IPostDomainRepository : IDomainRepository<Post>
    {
        Category GetCategory(int categoryId);

        Task Delete(int id);
        Task<Post> GetById(int id);
    }
}
