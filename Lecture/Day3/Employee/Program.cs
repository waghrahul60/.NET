﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("============Manager=================");
            Employee o1 = new Manager("Managet", "Amit", 300, 11);
            o1.DisplayData();
            Console.ReadLine();

            Console.WriteLine("============GenerelManager=================");
            Employee o2 = new GenerelManager("Derimilk", "general manager", "Mohit", 2000, 12);
            o2.DisplayData();
            Console.ReadLine();


            Console.WriteLine("============CEO=================");
            CEO o3 = new CEO("Rahul", 55000, 101);
            o3.DisplayData();


            Console.ReadLine();

        }
    }
    public abstract class Employee
    {
        public Employee(string name = "No name", decimal basic = 2500, short deptNo = 10)
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
        public abstract decimal Basic { get; set; }


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
        public virtual void DisplayData()
        {
            Console.WriteLine("Employee Id : " + EmpNo);
            Console.WriteLine("Employee Name : " + Name);
            Console.WriteLine("Employee department : " + DeptNo);
            //Console.WriteLine("Employee designation : " + designation);
            Console.WriteLine("===========================================");
        }

        public abstract decimal CalcNetSalary();
    }


    public class Manager : Employee
    {
        public int BASIS, DA, HRA;
        public decimal GROSS;

        public override decimal Basic {
            set
            {
                if (100 < value && value < 1000)
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Enter value between 100 and 1000 :");
                }
            }
            get
            {
                return basic;
            }
        }


        public Manager(string designation = "manager", string name = "Rahul", decimal basic = 2500, short deptNo = 10) : base(name, basic, deptNo)
        {
            this.Designation = designation;
        }
        private string designation;
        public string Designation
        {
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Designation should not be empty");
                }
                else
                {
                    designation = value;
                }
            }
            get
            {
                return designation;
            }
        }

        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.4 * BASIS);
            HRA = (int)(0.3 * BASIS);
            GROSS = Basic + DA + HRA;
            return GROSS;
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Employee designation : " + designation);
            Console.WriteLine("Employee Salaary : " + CalcNetSalary());
            Console.WriteLine("===========================================");
        }
    }

    public class GenerelManager : Manager
    {
        private string perks;
        public string Perks
        {
            get; set;
        }
        public override decimal Basic
        {
            set
            {
                if (1000 < value && value < 10000)
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Enter value between 1000 and 10000 :");
                }
            }
            get
            {
                return basic;
            }
        }



        public GenerelManager(string perks = "KitKat", string designation = "manager", string name = "Rahul", decimal basic = 2500, short deptNo = 10) : base(designation, name, basic, deptNo)
        {
            this.Perks = perks;
        }


        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.4 * BASIS);
            HRA = (int)(0.3 * BASIS);
            GROSS = Basic + DA + HRA + 500;
            return GROSS;
        }
        public override void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("Employee  perks : " + Perks);
            Console.WriteLine("===========================================");
        }
    }

    public class CEO : Employee
    {
        public override decimal Basic {
            set
            {
                if (10000 < value && value < 100000)
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Enter value between 10000 and 100000 :");
                }
            }
            get
            {
                return basic;
            }
        }

        public CEO(string name = "Rahul", decimal basic = 5000, short deptNo = 100) : base(name, basic, deptNo)
        {
           /* this.Name = name;
            this.Basic = basic;
            this.DeptNo = deptNo;*/
        }

        public int BASIS, DA, HRA;
        public decimal GROSS;
        public override decimal CalcNetSalary()
        {
            BASIS = Convert.ToInt32(this.Basic);
            DA = (int)(0.5 * BASIS);
            HRA = (int)(0.4 * BASIS);
            GROSS = Basic + DA + HRA;
            return GROSS;
        }

        public override sealed void DisplayData()
        {
            base.DisplayData();
            Console.WriteLine("CEO  Sal : " + CalcNetSalary());
            Console.WriteLine("===========================================");
        }
    }
}
