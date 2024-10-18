using TicketManager.Domain.Entities.Ticket;
using TicketManager.Domain.Enums;
using TicketManager.Infrastructure.Common.Persistence;

namespace TicketManager.WebApi.Common.Helpers
{
    public static class PrepareData
    {

        public static void PrepData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            SeedTickets(context);

        }

        private static void SeedTickets(AppDbContext? context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var tickets = new List<Ticket>();

            for (int i = 0; i < 100; i++)
            {
                tickets.Add(new Ticket
                {

                    Description = $"Description {i}",
                    Status = TicketStatus.Open,
                    CreationDate = DateTime.Now

                });
            }
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
