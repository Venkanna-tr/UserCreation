using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessWala.Application.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : CommandResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //var context = new ValidationContext(request);

            var failures = _validators
                 .Select(v => v.Validate(request))
                 .SelectMany(result => result.Errors)
                 .Where(f => f != null)
                 .ToList();

            return failures.Any()
                ? Errors(failures) : next();

        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new CommandResult();

            foreach (var failure in failures)
            {
                response.AddError(failure.PropertyName, failure.ErrorMessage);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
