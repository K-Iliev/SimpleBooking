using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking.Commands;
using Application.Booking.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Features
{
    public class BookingController : ApiBaseController
    {
        [HttpPost("get-available-hotels")]
        public async Task<ActionResult<IReadOnlyCollection<GetAvailableHotelsDto>>>
            Search([FromBody] GetAvailableHotelsQuery query)
                => await this.Send(query);

        [Authorize]
        [HttpPost("add-hotel")]
        public async Task
          AddHotel([FromBody] AddHotelCommand command)
              => await this.Send(command);
    }
}
