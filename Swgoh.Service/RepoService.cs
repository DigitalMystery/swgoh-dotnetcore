using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swgoh.Service
{
    public class RepoService
    {
        public HttpClient Client { get; }

        public RepoService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.swgoh.help/auth/signin/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            
            Client = client;
        }
    }
}
