using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Pso.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.Infra.CrossCutting.Filters
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _work;
        private readonly ILogger _logger;

        public UnitOfWorkFilter(IUnitOfWork work, ILoggerFactory loggerFactory)
        {
            _work = work;
            _logger = loggerFactory.CreateLogger<UnitOfWorkFilter>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Method.Equals("Post", StringComparison.OrdinalIgnoreCase)
                && !context.HttpContext.Request.Method.Equals("Put", StringComparison.OrdinalIgnoreCase)
                && !context.HttpContext.Request.Method.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                await next.Invoke();
            }
            else
            {
                string msg;

                if (_work == null)
                {
                    msg = "Instância não definida para a unidade de trabalho!";
                    _logger.LogError(msg);
                    throw new NotSupportedException(msg);
                }

                var executedContext = await next.Invoke();

                if (executedContext.Exception == null)
                {
                    msg = "Salvando mudanças para unidade de trabalho";
                    _logger.LogInformation(msg);
                    await _work.CommitAsync();
                }
                else
                {
                    msg = "Evite salvar as alterações para a unidade de trabalho devido a uma exceção";
                    _logger.LogInformation(msg);
                }
            }
        }
    }
}