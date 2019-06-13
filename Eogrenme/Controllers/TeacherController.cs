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
    public class TeacherController : Controller
    {
        
        // GET: Teacher
        [Authorize(Roles="öğretmen")]
        public ActionResult Index()
        {
            List<User> ogrenciler = new List<User>();
            // model.Ogrenciler = Database.Session.Query<User>().Where(x => x.Rolesin.Id(2)).ToList();
            var ogrenciler_hepsi = Database.Session.Query<User>().ToList();
            foreach(var item in ogrenciler_hepsi)
            {
                if(item.Roles[0].Id == 3)
                {
                    ogrenciler.Add(item);
                }
            }

            ViewData["ogrenciler"] = ogrenciler;
            return View(ogrenciler);
        }
        public ActionResult OgrenciNew()
        {
            return View(new OgrenciNew
            {
                Roles = Database.Session.Query<Role>().Select(role => new RoleCheckBox2
                {
                    Id = role.Id,
                    IsChecked = false,
                    Name = role.Name
                }).ToList()
            });
        }

        [HttpPost]
        public ActionResult OgrenciNew(OgrenciNew formData)
        {
            try
            {
                if (Database.Session.Query<User>().Any(x => x.Username == formData.Username))
                    ModelState.AddModelError("Username", "Username Must Be Unique");

                var user = new User()
                {
                    Email = formData.Email,
                    PasswordHash = formData.Password,
                    Username = formData.Username,

                };

                user.SetPassword(formData.Password);
 
                Database.Session.Save(user);
                Database.Session.Flush();
                Database.Session.Clear();

                var user_id = Database.Session.Query<User>().Where(x => x.Email == formData.Email).FirstOrDefault();
                Database.Session.CreateSQLQuery("INSERT INTO `elearning`.`role_users` (`user_id`,`role_id`) VALUES("+user_id.Id +","+"3" + ")").ExecuteUpdate();



                return RedirectToRoute("Teacher");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("Hata");
            }

        }


       private void SyncRoles(IList<RoleCheckBox2> checkBoxes, IList<Role> roles)
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

        public ActionResult OgrenciEdit(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new OgrenciEdit
            {
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPost]
        public ActionResult OgrenciEdit(int id, OgrenciEdit form)
        {
            var user = Database.Session.Get<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))
                ModelState.AddModelError("Kullanıcı Adı", "Kullanıcı adı benzersiz olmalıdır");
            if (!ModelState.IsValid)
                return View(form);
            user.Username = form.Username;
            user.Email = form.Email;

            Database.Session.Update(user);
            Database.Session.Flush();
            Database.Session.Clear();

            return RedirectToRoute("Teacher");
        }

        public ActionResult OgrenciResetPassword(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new OgrenciResetPassword()
            {
                Username = user.Username
            });
        }

        [HttpPost]
        public ActionResult OgrenciResetPassword(int id, OgrenciResetPassword formData)
        {
            var user = Database.Session.Get<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            formData.Username = user.Username;

            if (!ModelState.IsValid)
                return View(formData);
            user.SetPassword(formData.Password);

            Database.Session.Update(user);
            Database.Session.Flush();
            Database.Session.Clear();
            return RedirectToAction("Teacher");
        }

        [HttpPost]
        public ActionResult OgrenciDelete(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            try
            {
                Database.Session.Delete(user);
                Database.Session.Flush();
                Database.Session.Clear();
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
            return RedirectToRoute("Teacher");
        }






    }
}