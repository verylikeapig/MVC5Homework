using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Fliters
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {

            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}