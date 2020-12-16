using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================Simpleintrest=======================");
            Func<decimal , decimal , decimal, decimal> o = (p,n,r) => ((p*n*r)/100);
            Console.WriteLine(o(10, 20,30));

            Console.WriteLine("======================IsGreater=======================");
            Func<int, int, bool> o2 = (a, b) => (a > b);
            Console.WriteLine(o2(6,4));

            Console.WriteLine("======================GetBasic=======================");
            Func<Employee, decimal> o3 = (Employee) => (Employee.Salary);
            Console.WriteLine(o3(new Employee("Rahul",3500,55)));

            Console.WriteLine("========================IsEven=====================");
            Predicate<int> o4 = (a) => ((a % 2) == 0);
            Console.WriteLine(o4(11));

            Console.WriteLine("========================IsGreaterThan10000=====================");
            Predicate<Employee> o5 = (Employee) => (Employee.Salary > 10000);
            Console.WriteLine(o5(new Employee(salary: 20000)));
            Console.ReadLine();
        }
    }

    public class Employee
    {
        public Employee(string name = "No name", decimal salary = 2500, short deptNo = 10)
        {
            this.EmpNo = empNo;
            this.Name = name;
            this.Salary = salary;

        }
        private string name;
        public string Name
        {
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Enter a Correct Name");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        private short empNo;
        public short EmpNo
        {
            set
            {
                if (value != 0)
                {
                    empNo = value;

                }
                /* else
                 {
                     Console.WriteLine("Emp no should be greater then 0");
                 }*/

            }
            get
            {
                return empNo;
            }
        }

        private decimal salary;
        public decimal Salary
        {
            set
            {
                if (1000 < value && value < 50000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Enter value between 1000 and 5000 :");
                }
            }
            get
            {
                return salary;
            }
        }

        public void getData()
        {
            Console.WriteLine("Enter the emp ID : ");
            EmpNo = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter the emp Name : ");
            Name = Console.ReadLine();

            Console.WriteLine("Enter the emp Salary : ");
            Salary = Convert.ToDecimal(Console.ReadLine());
        }


        public void DisplayData()
        {
            Console.WriteLine("Employee Id : " + EmpNo);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee department : " + salary);
            Console.WriteLine("===========================================");
        }
    }
}
