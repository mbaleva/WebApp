namespace WebApp.Common.Domain
{
    using System.Threading.Tasks;

    public interface IDomainRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity);
    }
}
