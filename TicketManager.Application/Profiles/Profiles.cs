using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Application.Tickets.Commands.CreateTicket;
using TicketManager.Application.Tickets.Commands.UpdateTicket;
using TicketManager.Domain.Entities.Ticket;

namespace TicketManager.Application.Profiles
{
    public class Profiles : AutoMapper.Profile
    {
        public Profiles()
        {
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, UpdateTicketCommand>();
            CreateMap<CreateTicketDto, CreateTicketCommand>();
          

        }
    }
}
