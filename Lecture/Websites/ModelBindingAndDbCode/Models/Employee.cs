using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ModelBindingAndDbCode.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}