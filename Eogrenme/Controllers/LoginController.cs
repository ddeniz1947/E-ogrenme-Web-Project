using Eogrenme.Models;
using Eogrenme.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eogrenme.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(LoginAuth formData,string returnUrl)
        {
            var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == formData.Username);

            if (user == null)
                Eogrenme.Models.User.FakeHash();

          if (user == null || !user.CheckPassword(formData.Password))
                ModelState.AddModelError("Username", "Username or password is incorrect");
         
            if (!ModelState.IsValid)
            {
                return View();
            }


            FormsAuthentication.SetAuthCookie(formData.Username, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Content("Giris Yapildi");
        }
        
    }
}