using System.Web.Mvc;

namespace MVCValidationTest.Areas.Supervisor
{
    public class SupervisorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Supervisor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Supervisor_default",
                "Supervisor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MVCValidationTest.Areas.Supervisor.Controllers"} //This line is not mandatory
            );
        }
    }
}