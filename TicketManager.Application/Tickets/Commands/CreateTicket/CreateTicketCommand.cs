using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Enums;

namespace TicketManager.Application.Tickets.Commands.CreateTicket
{
    public record CreateTicketCommand( string Description, TicketStatus Status) : IRequest<TicketDto>;
}
