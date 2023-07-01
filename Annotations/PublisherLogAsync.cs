using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Api.Annotations
{
    public class PublisherLogAsync : IAsyncActionFilter
    {
        private readonly ILogger<PublisherLogAsync> _logger;

        public PublisherLogAsync(ILogger<PublisherLogAsync> logger)
        {
            _logger = logger;
        }

        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            Task<ActionExecutedContext> execution = next.Invoke();


            string requestParameters = await ReadJsonRequest(context.HttpContext.Request.Body);
            //string requsltParameters = await ReadJsonRequest(context.HttpContext.Request.Body);

            var log = new
            {
                method = context.HttpContext.Request.Method,
                request = requestParameters ?? context.HttpContext.Request.QueryString.ToString(),
                Datetime = DateTime.Now.ToLongTimeString(),
                contenType = context.HttpContext.Request.ContentType,

            };

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Logs_apis",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message_event = JsonConvert.SerializeObject(log);

                    var body = Encoding.UTF8.GetBytes(message_event);

                    channel.BasicPublish(exchange: "", routingKey: "Logs_apis", basicProperties: null, body: body);

                }
            }

        }

        private async Task<string> ReadJsonRequest(Stream stream)
        {
            string requestParameters = null;

            using (var reader = new StreamReader(stream))
            {
                requestParameters = await reader.ReadToEndAsync();
            }

            return requestParameters;
        }
    }
}