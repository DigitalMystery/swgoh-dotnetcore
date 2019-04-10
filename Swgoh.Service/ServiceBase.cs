using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Swgoh.Service
{
    public abstract class ServiceBase : RepoService
    {
        public static IConfiguration _configuration;

        protected ServiceBase() : base(new HttpClient())
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            
            _configuration = builder.Build();
        }
    }
}
