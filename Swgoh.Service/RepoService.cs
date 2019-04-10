using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Swgoh.Service.Constants;

namespace Swgoh.Service
{
    public abstract class RepoService
    {
        public HttpClient Client { get; }

        protected RepoService(HttpClient client)
        {
            client.BaseAddress = new Uri(UrlConstants.BaseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            
            Client = client;
        }
    }
}
