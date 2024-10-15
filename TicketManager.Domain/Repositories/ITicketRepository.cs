using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Entities.Ticket;

namespace TicketManager.Domain.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
    }
}
