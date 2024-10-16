using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TicketManager.Application.Common.Interfaces;
using TicketManager.Domain.Repositories;
using TicketManager.Infrastructure.Common.Persistence;
using TicketManager.Infrastructure.Common.Repositories;
using TicketManager.Infrastructure.Common.Security;
using TicketManager.Infrastructure.Common.Security.TokenGenerator;
using TicketManager.Infrastructure.Services;
using TicketManager.Infrastructure.Tickets.Persistence;

namespace TicketManager.Infrastructure
{
    public static class DIContainerRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("TicketManagerDb").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddAuth(configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SETTINGS, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF32.GetBytes(jwtSettings.SecretKey))
                });


            return services;
        }
    }
}
