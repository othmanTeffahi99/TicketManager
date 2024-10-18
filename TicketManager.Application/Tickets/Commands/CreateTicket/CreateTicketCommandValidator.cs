using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Application.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
        
            RuleFor(x => x.Description)
                .MaximumLength(2000)
                .NotEmpty();

            RuleFor(x => x.Status)
                .NotEmpty();
        }
    }
}
