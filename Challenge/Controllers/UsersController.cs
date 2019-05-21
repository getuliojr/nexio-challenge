using Challenge.Commons.Const;
using Challenge.Commons.Exceptions;
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
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
                throw new InvalidModelException();

            var checkUsername = userService.GetUserByUsername(model.Username);
            if (checkUsername != null)
                throw new Exception(ExceptionMessages.UsernameAlreadyInUse);

            userService.AddUser(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
