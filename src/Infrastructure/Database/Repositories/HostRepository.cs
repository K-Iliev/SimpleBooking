using System.Threading;
using System.Threading.Tasks;
using Application;
using Domain.Host;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    internal class HostRepository : IHostRepository
    {
        private readonly BookingDbContext _context;
        public HostRepository(BookingDbContext context)
        {
            this._context = context;
        }
        public async Task<Host> FindHost(string userId, CancellationToken cancellationToken)
             => await this._context.Users
                .Where(x => x.Id == userId)
                .Select(x => x.Host).FirstOrDefaultAsync();
        

        public async Task Save(Host entity, CancellationToken cancellationToken = default)
        {
            this._context.Update(entity);

            await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}
