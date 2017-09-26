using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Controllers
{
    public class AsynchronousDemoController : AsyncController
    {
        private readonly object _lock = new object();

        // GET: AsynchronousDemo
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            OperationOne();
            OperationTwo();
        }

        public ActionResult IndexCompleted(string result1, string result2)
        {
            ViewBag.Result1 = result1;
            ViewBag.Result2 = result2;
            return View();
        }

        private void OperationOne()
        {
            lock(_lock)
            {
                //Simulate long running operation
                Thread.Sleep(2000);
                AsyncManager.Parameters.Add("result1", "OperationOne result");
            }
            AsyncManager.OutstandingOperations.Decrement();
        }

        private void OperationTwo()
        {
            lock(_lock)
            {
                //Simulate long running operation
                Thread.Sleep(2000);
                AsyncManager.Parameters.Add("result2", "OperationTwo result");
            }
            AsyncManager.OutstandingOperations.Decrement();
        }
    }
}