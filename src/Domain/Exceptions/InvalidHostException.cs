namespace Domain.Exceptions
{
   public class InvalidHostException : BaseDomainException
    {
        public InvalidHostException()
        {
        }

        public InvalidHostException(string error) => this.Error = error;
    }
}
