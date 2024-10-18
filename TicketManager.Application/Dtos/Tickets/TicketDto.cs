using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Enums;

namespace TicketManager.Application.Dtos.Tickets
{
    /// <summary>
    /// The ticket data transfer object.
    /// </summary>
    public record TicketDto(int Id, string Description, TicketStatus Status, DateTimeOffset CreationDate);

}
