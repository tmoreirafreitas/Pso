using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Pso.Domain.Core.Pipelines
{
    public class MeasureTime<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public MeasureTime(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(typeof(MeasureTime<,>));
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = await next();
            var elapsed = stopWatch.Elapsed;
            _logger.LogInformation($"Tempo de execução do request {typeof(TRequest).FullName}: {elapsed}ms");
            return result;
        }
    }
}