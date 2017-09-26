using MVCValidationTest.Customizations;
using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MVCValidationTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This page should appear in a popup window.";

            return PartialView();
        }

        public async Task<ActionResult> LongRunningMethod(int waitSeconds)
        {
            var task = Task.Factory.StartNew<string>(() =>
                {
                    //Simulating long running operation
                    Task.Delay(waitSeconds * 1000);
                    return string.Format("Waited for {0} seconds", waitSeconds);
                });

            ViewBag.Message = await task;
            return View();
        }

        [OutputCache(Duration=20, VaryByParam="id")]
        public ActionResult CacheTest()
        {
            var cache = System.Web.HttpContext.Current.Cache;
            if (cache["DataCache"] == null)
            {
                cache.Add("DataCache", DateTime.Now.ToString("hh:mi:ss.fff"), null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10), System.Web.Caching.CacheItemPriority.Normal, null);
            }
            ViewBag.DataCache = cache["DataCache"];
            return View();
        }

        [OutputCache(CacheProfile="CustomCacheProfile")]
        public ActionResult CacheProfileTest()
        {
            return View("CacheTest");
        }

        public ActionResult ErrorTest()
        {
            throw new ApplicationException("This custom error should be shown on Custom Error Page");
        }

        public ActionResult About()
        {
            throw new ApplicationException("This custom error should be shown on Custom Error Page");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterViewModel { Income = 10000, BirthDate = new DateTime(2000, 12, 12) };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = model.Email + " registered successfully";
                Session["LoginId"] = model.Email;
                Session["Role"] = model.Role;

                if (Session["Role"] != null)
                    Debug.WriteLine("User is " + ((RoleType)Session["Role"]).ToString());
            }
            return View(model);
        }

        public ActionResult GetSampleImage()
        {
            var imagePath = Server.MapPath("~/App_Data/Parrot Flower Thailand.jpg");
            FileStream stream = System.IO.File.OpenRead(imagePath);
            Byte[] data = new Byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);            
            return new ImageResult(data, "image/jpg");
        }
    }
}