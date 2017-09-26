using MVCValidationTest.Customizations;
using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Controllers
{
    public class FiltersTestController : Controller
    {
        // GET: FiltersTest
        [CustomActionFilter(Order = 1)]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(RoleType.Admin)]
        public ActionResult AdminOnly()
        {
            return View();
        }
    }
}