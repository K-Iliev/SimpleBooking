using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using MediatR;

namespace Application.Hotels.Queries.HostHotels
{
    public class GetHostHotelsQuery : IRequest<IEnumerable<HostHotelsDto>>
    {
        public class GetHostHotelsQueryHandler : IRequestHandler<GetHostHotelsQuery, IEnumerable<HostHotelsDto>>
        {
            IHotelQueryRepository _hotelRepository;
            IUserContext _userContext;
            public GetHostHotelsQueryHandler(IHotelQueryRepository hotelRepository, IUserContext userContext)
            {
                this._hotelRepository = hotelRepository;
                this._userContext = userContext;
            }
            public  Task<IEnumerable<HostHotelsDto>> Handle(GetHostHotelsQuery request, CancellationToken cancellationToken)
                => this._hotelRepository.GetHotels<HostHotelsDto>(this._userContext.UserId);
        }
    }
}
