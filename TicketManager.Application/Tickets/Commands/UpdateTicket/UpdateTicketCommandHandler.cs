using AutoMapper;
using MediatR;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Repositories;

namespace TicketManager.Application.Tickets.Commands.UpdateTicket
{
    internal class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, TicketDto>
    {
        private readonly IRepository<Ticket> ticketRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public UpdateTicketCommandHandler(IRepository<Ticket> ticketRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.ticketRepository = ticketRepository;
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await ticketRepository.FindByIdAsync(request.Id, cancellationToken);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            ticket.Description = request.Description;
            ticket.Status = request.Status;

            await ticketRepository.UpdateAsync(ticket, cancellationToken);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return _mapper.Map<TicketDto>(ticket);
        }
    }
}