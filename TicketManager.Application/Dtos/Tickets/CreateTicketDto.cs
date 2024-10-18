using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Enums;

namespace TicketManager.Application.Dtos.Tickets
{
    public record CreateTicketDto(string Description, TicketStatus Status);

}
