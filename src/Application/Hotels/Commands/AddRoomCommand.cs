using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Booking;
using Domain.Host.Repositories;
using MediatR;

namespace Application.Hotels.Commands
{
   public class AddRoomCommand : IRequest<Unit>
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int RoomType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int HotelId { get; set; }

        public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Unit>
        {
            private readonly IUserContext _userContext;
            private readonly IHostDomainRepository _hostRepository;
            public AddRoomCommandHandler(IHostDomainRepository hostRepository, IUserContext userContext)
            {
                this._hostRepository = hostRepository;
                this._userContext = userContext;
            }
            public async Task<Unit> Handle(AddRoomCommand request, CancellationToken cancellationToken)
            {
                 var host = await this._hostRepository.FindHost(this._userContext.UserId, cancellationToken);
                var hotel = host.Hotels.Where(x => x.Id == request.HotelId).FirstOrDefault();
                hotel.AddRoom(request.RoomNumber,
                              request.Capacity,
                              request.RoomType, 
                              new Money(request.Amount, request.Currency));
                await this._hostRepository.Save(host);
                return Unit.Value;
                 
            }
        }
    }
}
