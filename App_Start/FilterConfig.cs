using MVCValidationTest.Customizations;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomErrorHandler());
        }
    }
}
