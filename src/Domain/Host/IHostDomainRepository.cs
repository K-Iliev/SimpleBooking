using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Host.Repositories
{
    public interface IHostDomainRepository : IDomainRepository<Host>
    {
        Task<Host> FindHost(string userId, CancellationToken cancellationToken);
    }
}
