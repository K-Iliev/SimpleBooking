using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Booking;
using MediatR;

namespace Application.Booking
{
    public class MakeReservationCommand : IRequest<Unit>
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int GuestCount { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Unit>
        {
            private readonly IBookingRepository _bookingRepository;
            public MakeReservationCommandHandler(IBookingRepository bookingRepository)
            {
                this._bookingRepository = bookingRepository;
            }

            public async Task<Unit> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
            {
                var hotel = await this._bookingRepository.Find(request.HotelId, cancellationToken);
                var room = await this._bookingRepository.GetRoom(request.HotelId, cancellationToken);

                var bookingPeriod = new BookingPeriod(request.CheckIn, request.CheckOut);
                var person = new Person(request.FirstName, request.LastName, request.Phone, request.Email);

                hotel.TryBook(bookingPeriod, person, room, request.GuestCount);
                await this._bookingRepository.Save(hotel, cancellationToken);
                return Unit.Value;
            }
        }

    }
}
