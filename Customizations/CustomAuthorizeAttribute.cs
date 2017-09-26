using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        private RoleType[] allowedRoles= new RoleType[0];
        public CustomAuthorizeAttribute(params RoleType[] allowedRoles)
        {
            this.allowedRoles = allowedRoles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Role"] == null)
                return false;
            else if (this.allowedRoles.Any(roleType => roleType == (RoleType)httpContext.Session["Role"]))
                return true;
            else
                return false;
            //return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}