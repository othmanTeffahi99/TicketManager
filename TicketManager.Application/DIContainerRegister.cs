using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TicketManager.Application.Common.Behaviors;

namespace TicketManager.Application
{
    public static class DIContainerRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DIContainerRegister).Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(typeof(DIContainerRegister).Assembly);

            return services;
        }
    }
}
