using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Common.Requests
{
    public record GetTicketsRequest(int PageNumbre, int PageSize);
}
