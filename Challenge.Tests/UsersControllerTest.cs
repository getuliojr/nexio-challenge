using Challenge.Controllers;
using Challenge.MockServices.UserServiceMock;
using Challenge.Models.User;
using Challenge.Services.UserService.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        UsersController _controller;
        IUserService _userService;

        public UserControllerTest()
        {
            _userService = new UserServiceMock();
            _controller = new UsersController(_userService);
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        
        [TestMethod]
        public void InsertUser_ShouldInsertUser()
        {
            var newItem = new UserModel
            {
                Name = "teste5",
                Password = "teste5",
                Username = "teste5"
            };

            var response = _controller.Post(newItem);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
