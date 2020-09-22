using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Booking.Specification
{
    public class SearchAvailableHotelsSpecification : Specification<Hotel>
    {
        private  DateTime CheckInDate { get; }
        private  DateTime CheckOutDate { get; }
        private  int GuestsNumber { get; }

        public SearchAvailableHotelsSpecification( DateTime checkInDate, DateTime checkOutDate, int guestsNumber)
        {
            this.CheckInDate = checkInDate;
            this.CheckOutDate = checkOutDate;
            this.GuestsNumber = guestsNumber;
        }

        public override Expression<Func<Hotel, bool>> ToExpression()
            => hotel => hotel.IsCapacityAvailableForPeriod(this.GuestsNumber, new BookingPeriod(this.CheckInDate, this.CheckOutDate));
        
    }
}
