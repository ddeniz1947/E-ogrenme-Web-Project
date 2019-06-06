using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eogrenme.ViewModels
{
    public class LoginAuth
    {
       
        [MaxLength(10)]
        [Required(ErrorMessage = "Username alanı için bilgi giriniz")]
        public string Username { get; set; }

       
        [MaxLength(10)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}