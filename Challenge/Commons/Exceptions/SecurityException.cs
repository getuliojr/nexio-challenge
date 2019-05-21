using Challenge.Commons.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge.Commons.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException() : base(ExceptionMessages.UserNotExist)
        {

        }
    }
}