using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Common.Interfaces;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Repositories;

namespace TicketManager.Application.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IRepository<Ticket> ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(IDateTimeProvider dateTimeProvider, IRepository<Ticket> ticketRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.ticketRepository = ticketRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
               
                Description = request.Description,
                Status = request.Status,
                CreationDate = dateTimeProvider.Now
            };

            var newTicket = await ticketRepository.AddAsync(ticket, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return _mapper.Map<TicketDto>(newTicket);
        }
    }
}
