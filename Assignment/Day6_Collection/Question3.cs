using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Question3
    {
        static void Main()
        {
            List<Employee3> list1 = new List<Employee3>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter empNo :");
                int EmpNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter Salary");
                decimal Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Name ");
                string Name = Console.ReadLine();
                list1.Add(new Employee3 { EmpNo = EmpNo, Salary = Salary, Name=Name });

            }
            Console.WriteLine("======List==========");
            foreach (Employee3 item in list1)
            {
                Console.WriteLine("Employee No : {0} | Emp Name : {1} | Emp Salary : {2}", item.EmpNo, item.Name, item.Salary);
            }
            Console.WriteLine("======================");

            
            Console.WriteLine("======Array==========");

            object[] arr = list1.ToArray();
            foreach (Employee3 item in arr)
            {
                Console.WriteLine("Employee No : {0} | Emp Name : {1} | Emp Salary : {2}", item.EmpNo, item.Name, item.Salary);
            }

            Console.ReadLine();
        }

    }
    public class Employee3
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
