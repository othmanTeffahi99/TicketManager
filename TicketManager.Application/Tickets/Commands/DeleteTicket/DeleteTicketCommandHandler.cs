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

namespace TicketManager.Application.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, TicketDto>
    {
        private readonly IRepository<Ticket> ticketRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteTicketCommandHandler(IRepository<Ticket> ticketRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.ticketRepository = ticketRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketDto> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await ticketRepository.FindByIdAsync(request.Id, cancellationToken);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            await ticketRepository.DeleteAsync(ticket, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return _mapper.Map<TicketDto>(ticket);
        }
    }
}