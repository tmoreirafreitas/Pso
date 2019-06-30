using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters
{
    public class RequestMiddliware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestMiddliware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestMiddliware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
              await  HandleExceptionAsync(context, ex);   
            }
        }

        private Task  HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code;
            string result;
            if (exception is NotFoundException notFoundException)
            {
                code = (int)HttpStatusCode.NotFound;
                result = JsonConvert.SerializeObject(new
                {
                    code,
                    message = notFoundException.Message
                });
            }
            else
            {
                code = (int)HttpStatusCode.InternalServerError;
                result = JsonConvert.SerializeObject(new
                {
                    code,
                    title = "Atenção",
                    message = "Encontramos uma falha ao tentar realizar esta operação no momento"
                });
                _logger.LogError(exception, "Exceção não tratada.", null);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
