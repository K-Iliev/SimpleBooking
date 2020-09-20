namespace Domain.Exceptions
{
    public class InvalidReservationException : BaseDomainException
    {
        public InvalidReservationException()
        {
        }

        public InvalidReservationException(string error) => this.Error = error;
    }
}
