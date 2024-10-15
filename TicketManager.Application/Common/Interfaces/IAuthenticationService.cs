using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Common.Security;

namespace TicketManager.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, string firstName, string lastName, CancellationToken token);

        Task<AuthenticationResult> LoginAsync(string email, string password, CancellationToken token);
    }
}
