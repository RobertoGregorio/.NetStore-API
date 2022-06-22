using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Annotations
{
    public class LogAsyncFilter : IAsyncActionFilter
    {
        private readonly ILogger<LogAsyncFilter> _logger;

        public LogAsyncFilter(ILogger<LogAsyncFilter> logger)
        {
            _logger = logger;
        }

        Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("OnActionExecutionAsync");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ContenType = {context.HttpContext.Request.ContentType}");

            Task<ActionExecutedContext> execution  = next.Invoke();

            _logger.LogInformation("OnActionExecutionAsync");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            
            return execution;

        }
    }
}