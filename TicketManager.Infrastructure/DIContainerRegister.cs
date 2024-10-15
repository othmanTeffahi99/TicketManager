using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TicketManager.Application.Common.Interfaces;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;
using TicketManager.Infrastructure.Common.Repositories;
using TicketManager.Infrastructure.Common.Security;
using TicketManager.Infrastructure.Services;

namespace TicketManager.Infrastructure
{
    public static class DIContainerRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("TicketManagerDb");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITicketRepository, ITicketRepository>();
            services.AddScoped<IUserRepository, IUserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtTokenGenerator, IJwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
