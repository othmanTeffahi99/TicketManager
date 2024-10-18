
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Enums;

namespace TicketManager.Application.Tickets.Commands.UpdateTicket
{
    public record UpdateTicketCommand(int Id ,string Description, TicketStatus Status) : IRequest<TicketDto>;
    
    
}
