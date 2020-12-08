using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            Employee[] arr = new Employee[a];
            for (int i = 0; i < a; i++)
            {
                //arr[i].Accept();
                arr[i] = new Employee();
                arr[i].getData();
            }
            Console.WriteLine("===========================================");
            
                decimal large = arr[0].Salary;
                for (int i = 0; i < a; i++)
                {
                     if (large < arr[i].Salary)
                      {
                           large = arr[i].Salary;
                      }

                }
                
                for (int i = 0; i < a; i++)
                 {
                    if (arr[i].Salary == large)
                     {
                        arr[i].DisplayData();
                    }
                }
            Console.WriteLine("===========================================");
            Console.WriteLine("Enter id :");
            int empId = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                if (arr[i].EmpNo == empId)
                {
                    arr[i].DisplayData();
                }
            }
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
                /*else
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
            EmpNo =  Convert.ToInt16(Console.ReadLine());

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
