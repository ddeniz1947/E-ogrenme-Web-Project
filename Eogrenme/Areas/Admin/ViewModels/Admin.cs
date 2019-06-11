using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eogrenme.Areas.Admin.ViewModels
{

    public class AdminIndex
    {
        public IEnumerable<User> Users { get; set; }

    }
    public class AdminNew
    {

        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       // [Required]
        public IList<RoleCheckBox> Roles { get; set; }

        [Required]
        public int  RoleID { get; set; }
    
    }

    public class RoleCheckBox
    {
        [Required]
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }

    public class AdminEdit
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(128)]
        public string Username { get; set; }
        public IList<RoleCheckBox> Roles { get; set; }
    }

    public class AdminResetPassword
    {
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}