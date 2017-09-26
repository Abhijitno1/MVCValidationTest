using MVCValidationTest.Customizations;
using MVCValidationTest.Models;
using MVCValidationTest.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Controllers
{
    public class ModelBindingTestController : Controller
    {
        // GET: ModelBindingTest
        public ActionResult Index()
        {            
            return View(StaticDataProviders.GetEmployeeList());
        }

        [HttpPost]
        public ActionResult Index(List<Employee> employees)
        {
            return View(employees);
        }

        public ActionResult ModelBindTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModelBindTest([ModelBinder(typeof(DatePartsModelBinder))]ModelBindViewModel model)
        {
            ViewBag.Message = string.Format("Input Date is {0}", model.InputDate);
            return View();
        }

    }
}