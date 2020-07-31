using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Pso.Domain.Core.Pipelines
{
    public class FailFastValidateCommand<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : ICommand<TResponse> where TResponse : ResultCommand
    {
        private readonly IEnumerable<IValidator> _validators;

        public FailFastValidateCommand(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new ResultCommand();
            foreach (var failure in failures)
            {
                response.ValidationResult.Errors.Add(failure);
            }
            return Task.FromResult(response as TResponse);
        }
    }
}