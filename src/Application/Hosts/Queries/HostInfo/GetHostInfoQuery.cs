using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.Hosts.Queries.HostInfo
{
    public class GetHostInfoQuery : IRequest<HostInfoDto>
    {
        public class GetHostHotelsQueryHandler : IRequestHandler<GetHostInfoQuery,HostInfoDto>
        {
            IHostQueryRepository _hostRepository;
            IUserContext _userContext;
            public GetHostHotelsQueryHandler(IHostQueryRepository hostRepository, IUserContext userContext)
            {
                this._hostRepository = hostRepository;
                this._userContext = userContext;
            }
            public Task<HostInfoDto> Handle(GetHostInfoQuery request, CancellationToken cancellationToken)
                => this._hostRepository.GetHostInfo(this._userContext.UserId, cancellationToken);
        }
    }
}
