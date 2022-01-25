namespace WebApp.Common.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Common.Domain;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => Data.Set<TEntity>();

        public async Task Save(TEntity entity)
        {
            Data.Update(entity);

            await Data.SaveChangesAsync();
        }
    }
}
