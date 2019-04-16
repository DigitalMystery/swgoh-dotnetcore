using Microsoft.Extensions.Configuration;
using Swgoh.Dto;
using Swgoh.Service.Constants;
using Swgoh.Service.Services;

namespace Swgoh.Service
{
    internal interface IAuthorizationService
    {
        LoginResponse Login();
    }

    internal class AuthorizationService : ServiceBase, IAuthorizationService
    {
        private readonly ISwgohFlurlService _swgohFlurlService;

        public AuthorizationService(ISwgohFlurlService swgohFlurlService)
        {
            _swgohFlurlService = swgohFlurlService;
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

            var loginResponse = _swgohFlurlService.AuthPost(path, user);

            Token = $"Bearer {loginResponse.AccessToken}";
            
            return loginResponse;
        }
    }
}
