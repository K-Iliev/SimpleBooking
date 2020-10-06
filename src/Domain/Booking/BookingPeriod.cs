using System;
using Domain.Common;
using Domain.Exceptions;

namespace Domain.Booking
{
    public class BookingPeriod : ValueObject
    {
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public BookingPeriod(DateTime checkIn, DateTime checkOut)
        {
            ValidatePeriod(checkIn,checkOut);
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
        }

        public bool OverlapWith(BookingPeriod bookingPeriod)
            => this.CheckIn.Date < bookingPeriod.CheckOut.Date && this.CheckOut.Date > bookingPeriod.CheckIn.Date;
        private void ValidatePeriod(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn < checkOut)
            {
                return;
            }

            throw new InvalidBookingPeriodException("Check-in date should be before check-out date");
        }
    }
}
