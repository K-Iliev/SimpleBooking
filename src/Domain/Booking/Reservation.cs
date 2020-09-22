using System;
using Domain.Common;
using Domain.Exceptions;

namespace Domain.Booking
{
    public class Reservation : Entity<int>
    {
        public ClientInfo  PrimaryClientInfo { get;  private set; }
        public BookingPeriod BookingPeriod  { get; private set; }
        public Room Room { get; private set; }
        public int GuestsCount { get; private set; }
        internal Reservation(BookingPeriod bookingPeriod, ClientInfo client,Room room, int guestsCount)
        {
            ValidateGuestsCount(room, guestsCount);
            this.PrimaryClientInfo = client;
            this.BookingPeriod = bookingPeriod;
            this.Room = room;
            this.GuestsCount = guestsCount;
        }

        private Reservation(int guestsCount)
        {
            this.GuestsCount = guestsCount;
        }

        private void ValidateGuestsCount(Room room , int guestsCount)
        {
            if (room.Capacity >= guestsCount)
            {
                return;
            }

            throw new InvalidReservationException("Too many guests for the room");
        }
    }
}
