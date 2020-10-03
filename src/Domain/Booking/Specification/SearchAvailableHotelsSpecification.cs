using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;

namespace Domain.Booking.Specification
{
    public class SearchAvailableHotelsSpecification : Specification<Hotel>
    {
        public override Expression<Func<Hotel, bool>> ToExpression()
            => hotel => hotel.IsOpen;       
    }
}
