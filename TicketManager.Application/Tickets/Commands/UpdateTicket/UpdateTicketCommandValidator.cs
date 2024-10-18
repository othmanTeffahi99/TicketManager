using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Application.Tickets.Commands.UpdateTicket
{
    internal class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Description)
                    .MaximumLength(2000)
                    .NotEmpty();

            RuleFor(x => x.Status)
                .NotEmpty();
        }
    }
}
