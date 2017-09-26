using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCValidationTest.Models
{
    public class ActionLog
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string IPAddress { get; set; }
        public DateTime RequestTimeStamp { get; set; }
    }
}