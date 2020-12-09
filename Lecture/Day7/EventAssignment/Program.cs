using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAssignment
{
   

    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("============Manager=================");
            Employee o1 = new Employee("Amit", 300, 11);
            o1.DisplayData();
            Console.ReadLine();

            Console.WriteLine("============GenerelManager=================");
            Employee o2 = new Employee("Mohit", 2000, 12);
            o2.DisplayData();
            Console.ReadLine();
          
        }
    }

public delegate void InvalidEmpIdEventHandler();
public delegate void InvalidEmpNameEventHandler();
public delegate void InvalidEmpSalEventHandler();

    public class Employee
    {
        public event InvalidEmpIdEventHandler InvalidEmpId;
        public event InvalidEmpNameEventHandler InvalidEmpName;
        public event InvalidEmpSalEventHandler InvalidEmpSal;


        public Employee(int empNo, string empName, decimal empSal) 
        {
            this.EmpNo = empNo;
            this.EmpName = empName;
            this.EmpSal = empSal;
        }

        private int empNo;
        public int EmpNo
        {
            get { return empNo}

            set 
            {

                if (value < 10) empNo = value;
                else
                {
                    invalidEmpId();
                }

            }
        }

        private string empName;
        public string EmpName
        {
            set
            {
                if (value == "" || value == null)
                {
                    invalidEmpName();
                }
                else
                {
                    empName = value;
                }
            }
            get
            {
                return empName;
            }
        }

        private decimal empSal;
        public decimal EmpSal
        {
            get { return empSal; }
            set
            {
                if (value < 1000)
                {
                    invalidEmpSal();
                }
                else empSal = value;
            }
        }
        public virtual void DisplayData()
        {
            Console.WriteLine("Employee Id : " + EmpNo);
            Console.WriteLine("Employee Name : " + EmpName);
            Console.WriteLine("Employee Salary : " + EmpSal);
            Console.WriteLine("===========================================");
        }

    }
    
}
