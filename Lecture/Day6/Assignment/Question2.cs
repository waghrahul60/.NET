using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Question2
    {
        static void Main1()
        {
            Employee2[] arr = new Employee2[2];

            for(int i =0; i< arr.Length; i++)
            {
                Console.WriteLine("Enter empNo :");
                int EmpNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter Salary");
                decimal Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Name ");
                string Name = Console.ReadLine();
                arr[i] = new Employee2();
                arr[i].EmpNo = EmpNo;
                arr[i].Salary = Salary;
                arr[i].Name= Name;

            }
            Console.WriteLine("======array==========");
            foreach (Employee2 item in arr)
            {
                Console.WriteLine("Employee No : {0} | Emp Name : {1} | Emp Salary : {2}",item.EmpNo,item.Name,item.Salary);
            }
            Console.WriteLine("======================");

            List<Employee2> list1 = arr.ToList<Employee2>();
            Console.WriteLine("======List==========");

            foreach (Employee2 item in list1)
            {
                Console.WriteLine("Employee No : {0} | Emp Name : {1} | Emp Salary : {2}", item.EmpNo, item.Name, item.Salary);
            }

            Console.ReadLine();
        }

    }
    public class Employee2
    {
        private int empNo;
        public int EmpNo
        {
            set; get;
        }
        private int salary;
        public decimal Salary
        {
            set; get;
        }

        private int name;
        public string Name
        {
            set; get;
        }

    }
}
