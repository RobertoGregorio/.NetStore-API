using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.Annotations
{

    public class LogSyncFilter : IActionFilter
    {
        private readonly ILogger<LogSyncFilter> _logger;

        public LogSyncFilter(ILogger<LogSyncFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Executando OnActionExecuted");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Executando OnActionExecuting");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        }
    }
}