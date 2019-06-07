using System.Web.Mvc;

namespace Eogrenme.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Panel","panel", new { controller="Admin" , action = "Index" });
            context.MapRoute("New", "new", new { controller = "Admin", action = "New" });

        }
    }
}