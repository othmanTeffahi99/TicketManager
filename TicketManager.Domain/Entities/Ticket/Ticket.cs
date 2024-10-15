using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Enums;

namespace TicketManager.Domain.Entities.Ticket
{
    public class Ticket : Entity<int>
    {
        public required string Description { get; set; }
        public required TicketStatus Status { get; set; }
        public required DateTimeOffset CreationDate { get; set; }
    }
}
