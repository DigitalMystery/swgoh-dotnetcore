using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Swgoh.Dto;
using Swgoh.Service;
using Swgoh.Service.Services;

namespace Swgoh.Tests
{
    [TestClass]
    public class AuthorizationServiceTests
    {
        private readonly IAuthorizationService _authorizationService;
        private Mock<ISwgohFlurlService> _swgohFlurlService;

        public AuthorizationServiceTests()
        {
            _swgohFlurlService = new Mock<ISwgohFlurlService>();
            _authorizationService = new AuthorizationService(_swgohFlurlService.Object);
        }

        [TestMethod]
        public void AuthorizeTest()
        {
            var loginResponse = new LoginResponse
            {
                AccessToken = "ad6e16c9698802859ec3b5296504e553e36ad728",
                ExpiresIn = 3600,
                TokenType = "bearer"
            };

            _swgohFlurlService
                .Setup(i => i.AuthPost(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(loginResponse);

            var response = _authorizationService.Login();

            Assert.AreEqual(loginResponse, response);
        }
    }
}
