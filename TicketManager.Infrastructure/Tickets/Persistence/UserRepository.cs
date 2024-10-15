using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketManager.Domain.Entities.User;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;
using TicketManager.Infrastructure.Common.Repositories;

namespace TicketManager.Infrastructure.Tickets.Persistence
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken token = default)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email, token);
        }
    }
}
