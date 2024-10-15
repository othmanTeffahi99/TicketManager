using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using TicketManager.Application.Common.Interfaces;

namespace TicketManager.Infrastructure.Common.Security.TokenGenerator
{
    public class JwtTokenGenerator(IOptions<JwtSettings> jwtOpts) : IJwtTokenGenerator
    {
       
        private JwtSettings JwtSettings => jwtOpts.Value;

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature
            );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(issuer: JwtSettings.Issuer, expires: DateTime.Now.AddMinutes(
                    jwtOpts.Value.ExpiryMinutes), audience: JwtSettings.Audience,
                claims: claims, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    
    }
}
