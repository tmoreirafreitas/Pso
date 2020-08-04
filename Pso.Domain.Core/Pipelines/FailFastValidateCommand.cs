using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Pso.Infra.CrossCutting.Filters;

namespace Pso.Domain.Core.Pipelines
{
    public class FailFastValidateCommand<TRequest, Unit> : IPipelineBehavior<TRequest, Unit>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly NotificationContext _notificationContext;

        public FailFastValidateCommand(IEnumerable<IValidator> validators, NotificationContext context)
        {
            _validators = validators;
            _notificationContext = context;
        }
       
        public Task<Unit> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any() ? Notify(failures) : next();
        }

        private Task<Unit> Notify(IEnumerable<ValidationFailure> failures)
        {
            var result = default(Unit);
            var validationResult = new ValidationResult(failures);
            _notificationContext.AddNotifications(validationResult);
            return Task.FromResult(result);
        }
    }
}