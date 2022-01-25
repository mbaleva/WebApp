namespace WebApp.Common.Application.Contracts
{
    using WebApp.Common.Domain;
    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
