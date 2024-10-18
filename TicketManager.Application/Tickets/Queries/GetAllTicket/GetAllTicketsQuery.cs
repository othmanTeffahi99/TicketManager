using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;

namespace TicketManager.Application.Tickets.Queries.GetAllTicket
{
    public record GetAllTicketsQuery(int pageNumber, int pageSize) : IRequest<List<TicketDto>>;
    
    
}
