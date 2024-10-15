using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Repositories
{
    public  interface IUnitOfWork
    {
        Task<bool> SaveChangeAsync(CancellationToken token);
    }
}
