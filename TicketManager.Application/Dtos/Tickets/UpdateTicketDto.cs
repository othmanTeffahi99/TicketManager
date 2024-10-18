using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Enums;

namespace TicketManager.Application.Dtos.Tickets
{
    /// <summary>
    /// The update ticket data transfer object.
    /// </summary>
    public record UpdateTicketDto(int Id, string Description, TicketStatus Status);

}
