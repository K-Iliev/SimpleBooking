using Domain.Common;

namespace Domain.Booking.Common
{
    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
