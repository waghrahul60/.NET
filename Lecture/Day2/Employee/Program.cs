﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Amol", 2500, 10);
            Employee o2 = new Employee("Amol", 2300);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();
            /*o1.GetData();
            o1.ShowData();*/
            /* Console.WriteLine(o1.Name);
             Console.WriteLine(o1.Basic);
             Console.WriteLine(o1.EmpNo);
             Console.WriteLine(o1.DeptNo);
             Console.WriteLine(o1.GetNetSalary());*/
            //o1.DisplayData();
            /* Console.WriteLine(o2.Name);
             Console.WriteLine(o2.Basic);
             Console.WriteLine(o2.EmpNo);
             Console.WriteLine(o2.GetNetSalary());*/
            /* o2.DisplayData();
             o3.DisplayData();
             o4.DisplayData();*/

            o1.DisplayData();
            o2.DisplayData();
            o3.DisplayData();



            o3.DisplayData();
            o2.DisplayData();
            o1.DisplayData();


            Console.ReadLine();
        }
    }

    public class Employee
    {  
        public Employee(string name="Rahul", decimal basic=2500, short deptNo=10)
        {
            this.EmpNo = ++empNo;
            this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;
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

        // private static int lastEmpNo = 0;
        private static int empNo = 0;
        public int EmpNo
        {
            get;
            
            private set;
        }

        protected decimal basic;
        public decimal Basic
        {
            set
            {
                if (1000 < value && value < 50000)
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Enter value between 1000 and 5000 :");
                }
            }
            get
            {
                return basic;
            }
        }

        private short deptNo;
        public short DeptNo
        {
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Depart no should be greater then 0");
                }
                else
                {
                    deptNo = value;
                }

            }
            get
            {
                return deptNo;
            }
        }

        public decimal GetNetSalary()
        {
            Salary sal = new Salary();
            sal.Basic = Basic;
            return sal.GetNetSalary2();

        }
        public void DisplayData()
        {
            Salary sal = new Salary();
            sal.Basic = Basic;
            Console.WriteLine("Employee Id : " + EmpNo);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee department : " + DeptNo);
            Console.WriteLine("Employee Salary : " + sal.GetNetSalary2());

            Console.WriteLine("===========================================");
        }
    }

    public class Salary : Employee
    {

        public int BASIS, DA, HRA;
        decimal GROSS;

        public decimal GetNetSalary2()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.4 * BASIS);
            HRA = (int)(0.3 * BASIS);
            GROSS = Basic + DA + HRA;
            return GROSS;
        }

    }
}
