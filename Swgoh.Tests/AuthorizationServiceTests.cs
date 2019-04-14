using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Swgoh.Service;

namespace Swgoh.Tests
{
    [TestClass]
    public class AuthorizationServiceTests
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationServiceTests()
        {
            _authorizationService = new AuthorizationService();
        }

        [TestMethod]
        public void AuthorizeTest()
        {
            var loginResponse = _authorizationService.Login();
        }

        ////private readonly AuthorizationService _authorizationService;

        //public AuthorizationServiceTests()
        //{
        //    //_authorizationService = new AuthorizationService();
        //}

        //[TestMethod]
        //public void AuthorizeTest()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Path.Combine(AppContext.BaseDirectory))
        //        .AddJsonFile("appsettings.json", optional: true);

        //    var _configuration = builder.Build();

        //    var authorizationSettings = _configuration.GetSection("SwgohAppSettings:Authorization");
        //}
        //private readonly IAuthorizationService _authorizationService;
        //private readonly IConfiguration _configuration;

        //public AuthorizationServiceTests(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _authorizationService = new AuthorizationService(
        //        new RepoService(new HttpClient()),
        //        _configuration
        //        );
        //}

        //[TestMethod]
        //public void AuthorizeTest()
        //{
        //    var temp = _authorizationService.Login();
        //    ////var typeClientModel = new Mock<ITypedClientModel>();

        //    //var gitHubIssues = new List<GitHubIssue>();

        //    ////typeClientModel.Setup(i => i.OnGet())
        //    ////    .Returns(Task.FromResult(temp));

        //    //var gitHubService = new Mock<IGitHubService>();

        //    //gitHubService.Setup(i => i.GetAspNetDocsIssues())
        //    //    .Returns(Task.FromResult(gitHubIssues));

        //    //var result = _typedClientModel.OnGet();

        //    ////var typeClientModel = new TypedClientModel(gitHubService.Object);

        //    ////var result = typeClientModel.OnGet();
        //}
    }
}
