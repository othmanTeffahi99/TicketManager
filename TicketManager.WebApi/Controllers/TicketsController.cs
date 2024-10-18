using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TicketManager.Application.Dtos.Tickets;
using TicketManager.Application.Tickets.Commands.CreateTicket;
using TicketManager.Application.Tickets.Commands.DeleteTicket;
using TicketManager.Application.Tickets.Commands.UpdateTicket;
using TicketManager.Application.Tickets.Queries.GetAllTicket;
using TicketManager.Domain.Common.Requests;

namespace TicketManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllTickets([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var tickets = await _mediator.Send(new GetAllTicketsQuery
            (
                 pageNumber,
               pageSize
            ));
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto ticketDto)
        {
            var command = _mapper.Map<CreateTicketCommand>(ticketDto);
            var ticket = await _mediator.Send(command);
            return Ok(ticket);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketDto ticketDto)
        {
            var command = _mapper.Map<UpdateTicketCommand>(ticketDto);
            var ticket = await _mediator.Send(command);
            return Ok(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var command = _mapper.Map<DeleteTicketCommand>(id);
            var ticket = await _mediator.Send(command);
            return Ok(ticket);
        }
    }
}
