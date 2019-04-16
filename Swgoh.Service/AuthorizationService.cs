using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Swgoh.Dto;
using Swgoh.Service.Constants;

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
            var appSettings = Configuration.GetSection("SwgohAppSettings").Get<AppSettings>();
            var user = $"{UrlConstants.Username}={appSettings.Login.UserName}" +
                       $"&{UrlConstants.Password}={appSettings.Login.Password}" +
                       $"&{UrlConstants.GrantType}={appSettings.Login.GrantType}" +
                       $"&{UrlConstants.ClientId}={appSettings.Login.ClientId}" +
                       $"&{UrlConstants.ClientSecret}={appSettings.Login.ClientSecret}";

            var path = Client.BaseAddress + UrlConstants.SignIn;

            var response = path.WithHeaders(new { Content_Type = UrlConstants.FormUrlencoded }).PostUrlEncodedAsync(user).Result;

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);

            Token = $"Bearer {loginResponse.AccessToken}";

            return loginResponse;
        }
    }
}
