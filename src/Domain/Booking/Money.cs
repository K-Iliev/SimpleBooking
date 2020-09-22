using Domain.Common;

namespace Domain.Booking
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public Money(decimal amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
