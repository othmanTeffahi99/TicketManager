using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Application.Common.Interfaces;

namespace TicketManager.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now  => DateTime.UtcNow;
        
    
    }
}
