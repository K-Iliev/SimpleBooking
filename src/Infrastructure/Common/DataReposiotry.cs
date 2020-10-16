using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Infrastructure.Common
{
    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Context = db;

        protected TDbContext Context { get; }

        protected IQueryable<TEntity> All() => this.Context.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Context.Update(entity);

            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }
}
