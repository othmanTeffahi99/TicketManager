using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace TicketManager.Application.Common.Behaviors
{
    /// <summary>
    /// The validation behavior.
    /// </summary>
    /// <typeparam name="TRequest"/>
    /// <typeparam name="TResponse"/>
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private readonly IValidator<TRequest>? _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehavior"/> class.
        /// </summary>
        /// <param name="validator">The validator.</param>
        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        /// <summary>
        /// Handle and return a task of type tresponse.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="next">The next.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><![CDATA[Task<TResponse>]]></returns>
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator == null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            StringBuilder errors = new StringBuilder();
            foreach (var error in validationResult.Errors)
            {
                errors.AppendLine($"{error.PropertyName} {error.ErrorMessage}");
            }

            return (dynamic)errors;
        }
    }
}
