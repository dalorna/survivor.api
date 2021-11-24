using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survivor.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();
            var iKey = config.GetSection("ApplicationInsights:InstrumentationKey").Value;
            CreateWebHostBuilder(args, iKey).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string iKey) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(builder =>
            {
                builder.AddApplicationInsights(iKey);
                builder.AddFilter<ApplicationInsightsLoggerProvider>("Application", LogLevel.Trace);
            });
    }
}
