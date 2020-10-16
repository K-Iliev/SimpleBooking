using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Hosts.Queries.HostInfo;
using Domain.Host;

namespace Application
{
    public interface IHostQueryRepository : IRepositoryBase<Host>
    {
        Task<HostInfoDto> GetHostInfo(string id, CancellationToken cancellationToken = default);
    }
}
