using System.Runtime.CompilerServices;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swgoh.Dto;
using Swgoh.Service.Constants;

[assembly: InternalsVisibleTo("Swgoh.Tests")]
namespace Swgoh.Service
{
    internal interface IAuthorizationService
    {
        LoginResponse Login();
    }

    internal class AuthorizationService : ServiceBase, IAuthorizationService
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
            var appSettings = _configuration.GetSection("SwgohAppSettings").Get<AppSettings>();
            var user = $"username={appSettings.Login.UserName}" +
                       $"&password={appSettings.Login.Password}" +
                       $"&grant_type={appSettings.Login.GrantType}" +
                       $"&client_id={appSettings.Login.ClientId}" +
                       $"&client_secret={appSettings.Login.ClientSecret}";

            var path = Client.BaseAddress + UrlConstants.SignIn;

            var response = path.WithHeaders(new { Content_Type = "application/x-www-form-urlencoded" }).PostUrlEncodedAsync(user).Result;

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);

            return loginResponse;
        }
    }
}
