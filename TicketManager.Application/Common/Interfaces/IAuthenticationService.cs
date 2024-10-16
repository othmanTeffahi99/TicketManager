using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Domain.Common.Security;

namespace TicketManager.Application.Common.Interfaces
{
    /// <summary>
    /// The authentication service interface.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Registers and return a task of type authenticationresult asynchronously.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="token">The token.</param>
        /// <returns><![CDATA[Task<AuthenticationResult>]]></returns>
        Task<AuthenticationResult> RegisterAsync(string email, string password, string firstName, string lastName, CancellationToken token);

        /// <summary>
        /// Logins and return a task of type authenticationresult asynchronously.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="token">The token.</param>
        /// <returns><![CDATA[Task<AuthenticationResult>]]></returns>
        Task<AuthenticationResult> LoginAsync(string email, string password, CancellationToken token);
    }
}
