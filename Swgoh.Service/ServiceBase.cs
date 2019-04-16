using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Swgoh.Service
{
    public abstract class ServiceBase : RepoService
    {
        public static IConfiguration Configuration;
        public static string Token { get; set; }

        protected ServiceBase() : base(new HttpClient())
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", true);
            
            Configuration = builder.Build();
        }
    }
}
