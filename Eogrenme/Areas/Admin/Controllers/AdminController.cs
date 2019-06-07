using NHibernate;
using Eogrenme.Areas.Admin.ViewModels;
using Eogrenme.ViewModels;
using Eogrenme.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace Eogrenme.Areas.Admin.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            AdminIndex model = new AdminIndex();
            model.Users = Database.Session.Query<User>().ToList();

            return View(model);
        }

        public ActionResult New()
        {
            return View(new AdminNew
            {
                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckBox
                {
                    Id = role.Id,
                    IsChecked = false,
                    Name = role.Name
                }).ToList()
            });
        }


        [HttpPost]
        public ActionResult New(AdminNew formData)
        {
            try
            {
                if (Database.Session.Query<User>().Any(x => x.Username == formData.Username))
                    ModelState.AddModelError("Username", "Username Must Be Unique");

                if (!ModelState.IsValid)
                    return View(formData);

                var user = new User()
                {
                    Email = formData.Email,
                    PasswordHash = formData.Password,
                    Username = formData.Username
                };

                SyncRoles(formData.Roles, user.Roles);
                user.SetPassword(formData.Password);

                
                Database.Session.Save(user);
                Database.Session.Flush();
                Database.Session.Clear();

                return RedirectToRoute("Panel");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("Hata");
            }
          
        }



        private void SyncRoles(IList<RoleCheckBox> checkBoxes, IList<Role> roles)
        {

            IList<Role> selectedRoles = new List<Role>();

            foreach (var role in Database.Session.Query<Role>())
            {
                var checkbox = checkBoxes.Single(c => c.Id == role.Id);
                checkbox.Name = role.Name;

                if (checkbox.IsChecked)
                {
                    selectedRoles.Add(role);
                }
            }
        
            foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
            {
                roles.Add(toAdd);
            }
            foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
            {
                roles.Add(toRemove);

            }
         
        }
    }

}