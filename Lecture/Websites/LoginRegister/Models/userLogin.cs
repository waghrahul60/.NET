using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LoginRegister.Models
{
    public class userLogin
    {
        [Required(ErrorMessage = "Please enter User Naame")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Enter only alphabets and numbers of Name")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}