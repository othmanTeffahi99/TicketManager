using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Application.Dtos.Tickets
{
    /// <summary>
    /// The create ticket data transfer object.
    /// </summary>
    public record CreateTicketDto(string Title, string Description, string Status);

}
