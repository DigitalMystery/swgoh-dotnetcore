using Swgoh.Dto;

namespace Swgoh.Service
{
    public class AuthService
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthService() : this(new AuthorizationService()) { }

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