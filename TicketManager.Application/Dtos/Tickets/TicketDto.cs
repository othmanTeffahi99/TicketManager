using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Application.Dtos.Tickets
{
    public record TicketDto(int Id, string Title, string Description, string Status);

}
