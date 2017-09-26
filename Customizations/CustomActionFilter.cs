using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionLog = new ActionLog
            {
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                ActionName = filterContext.ActionDescriptor.ActionName,
                IPAddress = filterContext.HttpContext.Request.UserHostAddress,
                RequestTimeStamp = filterContext.HttpContext.Timestamp
            };
            //ToDo: Log the actionlog here
            filterContext.Controller.ViewBag.ActionLog = actionLog;
            base.OnActionExecuting(filterContext);
        }
    }
}