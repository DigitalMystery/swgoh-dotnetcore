using Swgoh.Dto;
using Swgoh.Service.Services;

namespace Swgoh.Service
{
    public class AuthService
    {
        private readonly IAuthorizationService _authorizationService;
        private static readonly ISwgohFlurlService SwgohFlurlService;

        public AuthService() : this(new AuthorizationService(SwgohFlurlService)) { }

        private AuthService(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        public LoginResponse GetUserName()
        {
            return _authorizationService.Login();
        }
    }
}