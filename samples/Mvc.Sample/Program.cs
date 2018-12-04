using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Mvc.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    Debugger.Break();
                    var env = context.HostingEnvironment.EnvironmentName;
                    config.AddJsonFile("appsettings.json",
                            reloadOnChange: true, optional: false)
                        .AddJsonFile($"appsettings.{env}.json",
                            reloadOnChange: true, optional: true)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}