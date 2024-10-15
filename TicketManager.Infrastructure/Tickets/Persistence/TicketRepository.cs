using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;
using TicketManager.Infrastructure.Common.Repositories;

namespace TicketManager.Infrastructure.Tickets.Persistence
{
    public class TicketRepository(AppDbContext appDbContext) : RepositoryBase<Ticket>(appDbContext), ITicketRepository  
    {
    }
}
