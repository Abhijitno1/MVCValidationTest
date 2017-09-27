using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCValidationTest.API
{
    public class CarController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CarsStock> GetAllCarDetails()
        {
            CarsStock ST = new CarsStock();
            CarsStock ST1 = new CarsStock();
            List<CarsStock> li = new List<CarsStock>();

            ST.CarName = "Maruti Waganor";
            ST.CarPrice = "4 Lakh";
            ST.CarModel = "VXI";
            ST.CarColor = "Brown";

            ST1.CarName = "Maruti Swift";
            ST1.CarPrice = "5 Lakh";
            ST1.CarModel = "VXI";
            ST1.CarColor = "RED";

            li.Add(ST);
            li.Add(ST1);
            return li;
        }

        // GET api/<controller>/5
        public CarsStock Get(int id)
        {
            CarsStock ST = new CarsStock();
            if (id == 1)
            {
                ST.CarName = "Maruti Waganor";
                ST.CarPrice = "4 Lakh";
                ST.CarModel = "VXI";
                ST.CarColor = "Brown";
            }
            else
            {
                ST.CarName = "Maruti Swift";
                ST.CarPrice = "5 Lakh";
                ST.CarModel = "VXI";
                ST.CarColor = "RED";
            }
            return ST;
        }

        // POST api/<controller>
        public void PostCar([FromBody]CarsStock value)
        {
        }

        // PUT api/<controller>/5
        public void PutCar(int id, [FromBody]CarsStock value)
        {
        }

        // DELETE api/<controller>/5
        public void DeleteCar(int id)
        {
        }
    }
}