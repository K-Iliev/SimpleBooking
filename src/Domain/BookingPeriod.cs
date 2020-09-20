using System;
using Domain.Common;

namespace Domain
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
            => this.CheckIn < bookingPeriod.CheckOut && this.CheckOut > bookingPeriod.CheckIn;
        private void ValidatePeriod(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn < checkOut)
            {
                return;
            }

            // TODO: add specific exeption;
            throw new ArgumentException("Check in date should be before checkout date");
        }
    }
}
