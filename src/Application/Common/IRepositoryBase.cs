using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Common
{
    public interface IRepositoryBase<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
