using Challenge.Commons.Const;
using Challenge.Commons.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Challenge.Filters
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Authorization", out var values);
            var token = values.First();
            if (!JwtHelper.ValidateToken(token))
                throw new SecurityException(ExceptionMessages.InvalidToken);

            base.OnActionExecuting(actionContext);
        }
    }
}