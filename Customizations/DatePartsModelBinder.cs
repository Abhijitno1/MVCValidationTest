using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Customizations
{
    public class DatePartsModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(ModelBindViewModel))
            {
                bool validDate = true;
                DateParts dateParts = new DateParts();
                ModelBindViewModel result = new ModelBindViewModel();
                var Request = controllerContext.HttpContext.Request;
                int outVal;
                if (int.TryParse(Request["Day"], out outVal))
                    dateParts.Day = outVal;
                else
                    validDate = false;
                if (int.TryParse(Request["Month"], out outVal))
                    dateParts.Month = outVal;
                else
                    validDate = false;
                if (int.TryParse(Request["Year"], out outVal))
                    dateParts.Year = outVal;
                else
                    validDate = false;
                DateTime mydate = new DateTime();
                if (validDate)
                {
                    try
                    {
                        mydate = new DateTime(dateParts.Year, dateParts.Month, dateParts.Day);
                    }
                    catch
                    {
                        validDate = false;
                    }
                }
                if (validDate)
                {
                    result.InputDate = mydate;
                    result.DateParts = dateParts;
                }
                else
                {
                    bindingContext.ModelState.AddModelError("ModelBinding", "Invalid Input Date");
                }
                return result;
            }
            else
                return base.BindModel(controllerContext, bindingContext);
        }
    }
}