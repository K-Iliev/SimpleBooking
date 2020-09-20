using System;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Reservation
    {
        public ClientInfo  PrimaryClientInfo { get;  private set; }
        public BookingPeriod BookingPeriod  { get; private set; }
        public Room Room { get; private set; }
        public int GuestsCount { get; private set; }
        public Reservation(BookingPeriod bookingPeriod, ClientInfo client,Room room, int guestsCount)
        {
            ValidateGuestsCount(room, guestsCount);
            this.PrimaryClientInfo = client;
            this.BookingPeriod = bookingPeriod;
            this.Room = room;
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
