﻿using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eogrenme.ViewModels
{
    public class TeacherIndex
    {
        public IEnumerable<User> Ogrenciler { get; set; }
    }
    public class OgrenciNew
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // [Required]
        public IList<RoleCheckBox2> Roles { get; set; }

        [Required]
        public int RoleID { get; set; }
    }

    public class RoleCheckBox2
    {
        [Required]
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }
    public class OgrenciEdit
    {
        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(128)]
        public string Username { get; set; }
        public IList<RoleCheckBox2> Roles { get; set; }
    }

    public class OgrenciResetPassword
    {
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}