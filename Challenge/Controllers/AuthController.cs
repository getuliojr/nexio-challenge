using Challenge.Commons.Exceptions;
using Challenge.Commons.Helper;
using Challenge.Models.User;
using Challenge.Services.UserService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] AuthUserModel model)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelException();

            var userInfo = userService.GetUserByUsernameAndPassword(model.Username, model.Password);
            if (userInfo == null)
                throw new SecurityException();

            var token = JwtHelper.CreateToken(userInfo.Username, userInfo.UserId);
            return Request.CreateResponse(HttpStatusCode.OK, token);
        }
    }
}
