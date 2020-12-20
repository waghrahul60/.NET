using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LoginRegister.Models
{
    public class users
    {
      
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter User Naame")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Enter only alphabets and numbers of Name")]
        public string LoginName { get; set; }

        
        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter Full Name")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Enter only alphabets and numbers of Name")]
        public string FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter Email Id")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        public int CityId { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter Phone")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Phone")]
        public IEnumerable<SelectListItem> cities { get; set; }

    }
}
