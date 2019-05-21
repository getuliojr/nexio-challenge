using System.Net;
using System.Net.Http;
using System.Web.Http;
using Challenge.Controllers;
using Challenge.MockServices.UserServiceMock;
using Challenge.Models.User;
using Challenge.Services.UserService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests
{
    [TestClass]
    public class AuthControllerTest
    {
        AuthController _controller;
        IUserService _userService;

        public AuthControllerTest()
        {
            _userService = new UserServiceMock();
            _controller = new AuthController(_userService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        
        [TestMethod]
        public void AuthUser_ShouldAuthenticateUser()
        {
            var authUserModel = new AuthUserModel
            {
                Username = "teste2",
                Password = "teste2"
            };

            var content = _controller.Post(authUserModel);
            string token = content.Content.ReadAsAsync<string>().Result;

            Assert.AreEqual(HttpStatusCode.OK, content.StatusCode);
            Assert.IsNotNull(token);
        }
    }
}
