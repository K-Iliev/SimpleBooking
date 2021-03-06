﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking;
using Application.Hotels.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Features
{
    public class BookingController : ApiBaseController
    {
        [HttpGet("get-available-hotels")]
        public async Task<ActionResult<IReadOnlyCollection<GetAvailableHotelsDto>>>
            Search([FromQuery] GetAvailableHotelsQuery query)
                => await this.Send(query);


        [HttpPost("book")]
        public async Task
           Book([FromBody] MakeReservationCommand query)
               => await this.Send(query);
    }
}
