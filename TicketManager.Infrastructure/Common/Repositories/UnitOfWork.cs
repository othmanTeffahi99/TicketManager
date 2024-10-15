using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;

namespace TicketManager.Infrastructure.Common.Repositories
{
    public class UnitOfWork (AppDbContext appDbContext) : IUnitOfWork
    {
        public async Task<bool> SaveChangeAsync(CancellationToken token)
        {
           return  await appDbContext.SaveChangesAsync(token) is not 0 ;
        }
    }
}
