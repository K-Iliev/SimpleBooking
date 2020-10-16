using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Hosts.Queries.HostInfo;
using Application.Hotels.Commands;
using Application.Hotels.Queries.HostHotels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Features
{
    public class HostController : ApiBaseController
    {
        [Authorize]
        [HttpPost("add-hotel")]
        public async Task
        AddHotel([FromBody] AddHotelCommand command)
            => await this.Send(command);

        [Authorize]
        [HttpPost("add-room")]
        public async Task
        AddRoom([FromBody] AddRoomCommand command)
            => await this.Send(command);


        [Authorize]
        [HttpGet("get-hotels")]
        public async Task<ActionResult<IEnumerable<HostHotelsDto>>>
      GetHotels([FromQuery] GetHostHotelsQuery query)
          => await this.Send(query);

        [Authorize]
        [HttpGet("info")]
        public async Task<ActionResult<HostInfoDto>>
       GetInfo([FromQuery] GetHostInfoQuery query)
        => await this.Send(query);
    }
}
