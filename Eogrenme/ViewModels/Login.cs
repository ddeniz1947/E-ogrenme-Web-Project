using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eogrenme.ViewModels
{
    public class LoginAuth
    {
       
        [MaxLength(40)]
        [Required(ErrorMessage = "Username alanı için bilgi giriniz")]
        public string Username { get; set; }

       
        [MaxLength(40)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}