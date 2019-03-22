using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swgoh.Service
{
    public class Authorization
    {
        private static readonly HttpClient client = new HttpClient();

        public void Authorize()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var msg = stringTask.Result;
            Console.Write(msg);
        }
    }
}
