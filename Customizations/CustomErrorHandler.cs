using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class CustomErrorHandler: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var errorInfo = new
            {
                ControllerName = filterContext.Controller.GetType().Name,
                ExceptionMessage = filterContext.Exception.Message
            };
            //Log the exception here
            base.OnException(filterContext);
        }
    }
}