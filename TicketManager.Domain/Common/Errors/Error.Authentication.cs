using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Domain.Common.Errors
{
    public static partial class CommonErrors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid credentials.");
        }
    }
