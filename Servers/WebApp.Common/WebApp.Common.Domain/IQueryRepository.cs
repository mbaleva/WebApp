namespace WebApp.Common.Domain
{
    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
