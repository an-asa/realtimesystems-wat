using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieZaworemDoplywu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //statyczne pory to raczej dobry pomys�
                    string strURL = string.Format(@"http://{0}:{1}", "localhost", "4003");
                    webBuilder
                        .UseUrls(strURL)
                        .UseStartup<Startup>();
                });
    }
}
