using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Swgoh.Dto;
using Swgoh.Dto.Requests;
using Swgoh.Service.Constants;

namespace Swgoh.Service.Services
{
    internal interface ISwgohFlurlService
    {
        LoginResponse AuthPost(string path, string user);
        string SwgohPost(string path, PlayerRequest playerRequest);
    }

    internal class SwgohFlurlService : ServiceBase, ISwgohFlurlService
    {
        public SwgohFlurlService()
        {
            FlurlHttp.Configure(c =>
            {
                c.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            });
        }

        public LoginResponse AuthPost(string path, string user)
        {
            var response = path.WithHeaders(new { Content_Type = UrlConstants.ApplicationUrlencoded }).PostUrlEncodedAsync(user).Result;

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);

            return loginResponse;
        }

        public string SwgohPost(string path, PlayerRequest playerRequest)
        {
            var response = path.WithHeaders(new { Content_Type = UrlConstants.ApplicationJson, Authorization = Token }).PostJsonAsync(playerRequest).Result;

            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
