﻿using System;

namespace Domain.Booking
{
    public class Booking
    {
        public Hotel Hotel { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public int GuestsNumber { get; private set; }

        internal Booking(Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int guestsNumber)
        {
            this.Hotel = hotel;
            this.CheckInDate = checkInDate;
            this.CheckOutDate = checkOutDate;
            this.GuestsNumber = guestsNumber;
        }
    }
}
