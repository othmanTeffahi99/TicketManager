﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using TicketManager.Application.Common.Interfaces;
using TicketManager.Domain.Common.Security;
using TicketManager.Domain.Entities.User;
using TicketManager.Domain.Enums;
using TicketManager.Domain.Repositories;

namespace TicketManager.Infrastructure.Common.Security
{
    public class AuthenticationService
(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IRepository<User> repository, IUnitOfWork unitOfWork,
    IDateTimeProvider timeProvider, ILogger logger) : IAuthenticationService
    {
        private const int Keysize = 64;
        private const int Iterations = 35000;
        readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;


        public async Task<AuthenticationResult> RegisterAsync(string email, string password, string firstName,
            string lastName, CancellationToken token = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(email);
            ArgumentException.ThrowIfNullOrEmpty(password);
            ArgumentException.ThrowIfNullOrEmpty(firstName);
            ArgumentException.ThrowIfNullOrEmpty(lastName);
            // Check if the user already exists
            var user = await userRepository.GetUserByEmailAsync(email, token);

            if (user is null)
            {
                var (passwordHash, salt) = HashPassword(password);

                // Create the user (generate Unique id ID)

                logger.Debug($"PasswordHash:{Convert.ToBase64String(passwordHash)} \n PasswordSalt: {Convert.ToBase64String(salt)}");

                var newUser = await repository.AddAsync(new User
                {
                    Id = new Guid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PasswordHash = passwordHash,
                    PasswordSalt = salt,
                    CreatedAt = timeProvider.Now,
                    UpdatedAt = timeProvider.Now,
                    Role = Role.User
                }, token);

                await unitOfWork.SaveChangeAsync(token);

                return new AuthenticationResult(newUser.Id, newUser.FirstName, newUser.LastName, newUser.Email, null!);
            }

            logger.Warning($"the user with this email {email} is already exists");
            return await Task.FromResult<AuthenticationResult>(null!);

        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password, CancellationToken toekToken = default)
        {
            ArgumentException.ThrowIfNullOrEmpty(email);
            ArgumentException.ThrowIfNullOrEmpty(password);

            //Check if the user is exists
            var user = await userRepository.GetUserByEmailAsync(email);
            if (user is null)
            {
                logger.Warning($"there is no user with this email {email}");
                return await Task.FromResult<AuthenticationResult>(null!);
            }

            //Check the password is valid 
            if (IsPasswordValid(password, user.PasswordHash, user.PasswordSalt) is false)
            {
                logger.Warning("the given password is not valid");
                return await Task.FromResult<AuthenticationResult>(null!);
            }

            //Generate the token  
            var token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            //Return result with the token 
            return new AuthenticationResult(user.Id, user.FirstName, user.LastName, user.Email, token);

        }


        private bool IsPasswordValid(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), passwordSalt, Iterations,
                _hashAlgorithmName,
                Keysize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, passwordHash);
        }


        private (byte[] passwordHash, byte[] passwordSalt) HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(Keysize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, Iterations, _hashAlgorithmName,
                Keysize);

            return (hash, salt);
        }
    }
}
