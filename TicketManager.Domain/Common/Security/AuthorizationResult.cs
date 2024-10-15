using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Common.Security
{
    public record AuthenticationResult(Guid UserId, string FirstName, string LastName, string Email, string Token);

}
