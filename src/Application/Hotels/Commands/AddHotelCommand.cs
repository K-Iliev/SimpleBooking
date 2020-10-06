using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Domain.Booking.Factories;
using MediatR;

namespace Application.Hotels.Commands
{
    public class AddHotelCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public class AddHotelCommandHandler : IRequestHandler<AddHotelCommand, Unit>
        {
            private readonly IHotelFactory _hotelFactory;
            private readonly IBookingRepository _bookingRepository;
            private readonly IHostRepository _hostRepository;
            private readonly IUserContext _userContext;
            public AddHotelCommandHandler(
                IHotelFactory hotelFactory,
                IBookingRepository bookingRepository,
                IUserContext userContext,
                IHostRepository hostRepository)
            {
                this._hotelFactory = hotelFactory;
                this._bookingRepository = bookingRepository;
                this._userContext = userContext;
                this._hostRepository = hostRepository;
            }

            public async Task<Unit> Handle(AddHotelCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userContext.UserId;
                var host = await this._hostRepository.FindHost(userId, cancellationToken);
                var hotel =  this._hotelFactory.WithLocation(request.Location).WithName(request.Name).Build();
                host.AddHotel(hotel);
                await this._bookingRepository.Save(hotel, cancellationToken);
                return Unit.Value;
            }
        }
    }
}
