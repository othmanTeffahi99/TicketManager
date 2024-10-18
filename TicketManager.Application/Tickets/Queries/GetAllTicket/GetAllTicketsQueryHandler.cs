using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Repositories;

namespace TicketManager.Application.Tickets.Queries.GetAllTicket
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
    {
      
        private readonly IRepository<Ticket> ticketRepository;
     
        private readonly IMapper _mapper;

        public GetAllTicketsQueryHandler(IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            this.ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = (await ticketRepository.GetAllAsync(request.pageNumber, request.pageSize ,cancellationToken)).ToList();
            return _mapper.Map<List<TicketDto>>(tickets);
        }
    }
}
