namespace Domain.Exceptions
{
    class InvalidBookingPeriodException : BaseDomainException
    {
        public InvalidBookingPeriodException()
        {
        }

        public InvalidBookingPeriodException(string error) => this.Error = error;
    }
}
