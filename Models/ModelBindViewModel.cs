using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCValidationTest.Models
{
    public class ModelBindViewModel
    {
        public DateTime InputDate { get; set; }
        public DateParts DateParts { get; set; }
    }

    public class DateParts
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

    }
}