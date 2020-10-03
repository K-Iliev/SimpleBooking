using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Host;

namespace Application
{
    public interface IHostRepository : IRepositoryBase<Host>
    {
        Task<Host> FindHost(string userId, CancellationToken cancellationToken);
    }
}
