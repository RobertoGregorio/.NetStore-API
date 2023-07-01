using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            // .ConfigureAppConfiguration((hostingContext, config) =>
                // {
                //     var settings = config.Build();
                //     Serilog.Log.Logger = new LoggerConfiguration()
                //         .Enrich.FromLogContext()
                //         .WriteTo.Elasticsearch(
                //             options:
                //                 new ElasticsearchSinkOptions(
                //                     new Uri(settings["Elasticsearch:Uri"]))
                //                 {
                //                     AutoRegisterTemplate = true,
                //                     AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                //                     IndexFormat = "apiproducts-{0:yyyy.MM}"
                //                 })
                //         .WriteTo.Console()
                //         .CreateLogger();
                // })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
