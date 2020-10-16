using Application.Common.Mapping;
using Domain.Host;

namespace Application.Hosts.Queries.HostInfo
{
    public class HostInfoDto : IMapFrom<Host>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
