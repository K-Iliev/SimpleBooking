using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Features
{
    public class BookingController : ApiBaseController
    {
        [HttpPost]
        public async Task<ActionResult<IReadOnlyCollection<GetAvailableHotelsDto>>>
            Search([FromBody] GetAvailableHotelsQuery query)
        {
            var result =  await this.Mediator.Send(query);
            return Ok(result);
        }

    }
}
