using System.Threading;
using System.Threading.Tasks;
using Application;
using Domain.Host;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Common;
using Infrastructure.Hotelship;
using Domain.Host.Repositories;
using Application.Hosts.Queries.HostInfo;
using AutoMapper;

namespace Infrastructure.Database.Repositories
{
    internal class HostRepository : DataRepository<IBookingDbContext, Host>,
                                    IHostDomainRepository, IHostQueryRepository
    {
        private readonly IMapper _mapper;

        public HostRepository(IBookingDbContext context, IMapper mapper)
            : base(context)
        {
            this._mapper = mapper;
        }
        public async Task<Host> FindHost(string userId, CancellationToken cancellationToken)
             => await this.Context.Users
                                .Include(x=>x.Host)
                                .ThenInclude(x=>x.Hotels)
                            .Where(x => x.Id == userId)
                            .Select(x => x.Host)
                            .FirstOrDefaultAsync();

        public  Task<HostInfoDto> GetHostInfo(string id, CancellationToken cancellationToken = default)
         =>  this._mapper.ProjectTo<HostInfoDto>(this.Context.Users.Where(x => x.Id == id)
                            .Select(x => x.Host)).FirstOrDefaultAsync();
    }
}
