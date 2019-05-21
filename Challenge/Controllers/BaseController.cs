using Challenge.Commons.Helper;
using Challenge.Models.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Challenge.Controllers
{
    public class BaseController : ApiController
    {
        protected UserInfo GetUserInfo()
        {
            Request.Headers.TryGetValues("Authorization", out var values);
            var token = values.First();

            var jwtToken = JwtHelper.ReadToken(token);
            var payload = jwtToken.Payload;

            return new UserInfo
            {
                UserId = (string)payload["user_id"],
                Username = (string)payload["username"]
            };
        }
    }
}
