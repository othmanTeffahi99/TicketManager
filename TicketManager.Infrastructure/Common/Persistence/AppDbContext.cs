using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Entities.User;

namespace TicketManager.Infrastructure.Common.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> appContextOptions ): base(appContextOptions) 
        {
            
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
