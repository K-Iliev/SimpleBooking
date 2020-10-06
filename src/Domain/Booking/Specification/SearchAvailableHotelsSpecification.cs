using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Booking.Specification
{
    public class SearchAvailableHotelsSpecification : Specification<Hotel>
    {
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public SearchAvailableHotelsSpecification(DateTime checkIn, DateTime checkOut)
        {
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
        }
        public override Expression<Func<Hotel, bool>> ToExpression()
            => hotel => hotel.IsOpen &&
                        !hotel.Reservations
                           .Any(x=> x.BookingPeriod.CheckIn < CheckOut &&
                                 x.BookingPeriod.CheckOut > CheckIn);       
    }
}
