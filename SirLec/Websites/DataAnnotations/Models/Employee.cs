using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace DataAnnotations.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }
        
        [Range(1000, 500000, ErrorMessage = "Please enter values between 1000-500000")]
        [MaxLength(6), MinLength(4)]
        [Display(Name = "Basic Salary")]
        [DataType(DataType.Currency)]
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }
        
        [ScaffoldColumn(false)]
        public string Dummy { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }
    }
}





//Data Annotations
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.7

//DataType
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatype?view=netframework-4.7