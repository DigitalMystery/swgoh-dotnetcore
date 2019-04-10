using System.Configuration;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Swgoh.Dto;

namespace Swgoh.Service
{
    public class AuthorizationService : ServiceBase
    {
        public AuthorizationService()
        {
            FlurlHttp.Configure(c =>
            {
                c.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            });
        }

        public LoginResponse Login()
        {
            var authorizationSettings = _configuration.GetSection("SwgohAppSettings:Authorization");
            var user = $"username={ConfigurationManager.AppSettings["AppSettings:username"]}" +
                       $"&password{ConfigurationManager.AppSettings["password"]}" +
                       $"&grant_type{ConfigurationManager.AppSettings["grantType"]}" +
                       $"&client_id{ConfigurationManager.AppSettings["clientId"]}" +
                       $"&client_secret{ConfigurationManager.AppSettings["clientSecret"]}";

            var path = Client.BaseAddress.ToString();

            var response = path.WithHeaders(new { Content_Type = "application/x-www-form-urlencoded" }).PostUrlEncodedAsync(user).Result;

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);

            return loginResponse;
        }
    }
}
