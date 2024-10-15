using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketManager.Domain.Entities.Ticket;

namespace TicketManager.Application.Tickets.Commands.CreateTicket
{
    public record CreateTicketCommand(Ticket ticket) : IRequest;
}
