
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;

namespace TicketManager.Application.Tickets.Commands.DeleteTicket
{
    public record DeleteTicketCommand(int Id) : IRequest<TicketDto>;


}
