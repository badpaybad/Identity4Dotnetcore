using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity4WithDotnetcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var host = WebHost.CreateDefaultBuilder(args)
                 // .UseKestrel()
                //.UseUrls("http://localhost:5000")
                .UseContentRoot(basePath)
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            
            host.Run();
        }
        
    }
}
