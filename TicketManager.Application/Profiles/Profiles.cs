using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Entities.Ticket;

namespace TicketManager.Application.Profiles
{
    /// <summary>
    /// The profiles.
    /// </summary>
    public class Profiles : AutoMapper.Profile 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Profiles"/> class.
        /// </summary>
        public Profiles()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<UpdateTicketDto, Ticket>();

        }
    }
}
