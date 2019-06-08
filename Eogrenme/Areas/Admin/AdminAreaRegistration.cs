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
            context.MapRoute("Panel","panel", new { controller="Admins" , action = "Index" });
            context.MapRoute("New", "new", new { controller = "Admins", action = "New" });
            context.MapRoute("Edit", "edit", new { controller = "Admins", action = "Edit" });
            context.MapRoute("ResetPassword", "resetpassword", new { controller = "Admins", action = "ResetPassword" });
            context.MapRoute("Delete", "delete", new { controller = "Admins", action = "Delete" });
        }
    }
}