using System;
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
            Manager o1 = new Manager("Manager", "Amit", 300, 11);
            o1.DisplayData();
            o1.Update();
            o1.Delete();
            o1.Insert();
            Console.ReadLine();

            Console.WriteLine("============GenerelManager=================");
            GenerelManager o2 = new GenerelManager("Derimilk", "general manager", "Mohit", 2000, 12);
            o2.DisplayData();
            o2.Update();
            o2.Delete();
            o2.Insert();
            Console.ReadLine();

            Console.WriteLine("============CEO=================");
            Employee o3 = new CEO("Rahul", 55000, 101);
            o3.DisplayData();
            o3.demo();
            o3.Update();
            o3.Delete();
            o3.Insert();

            Console.ReadLine();

        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public abstract class Employee : IDbFunctions
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
        public void demo()
        {
            Console.WriteLine("Rahul Wagh");
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

        public virtual void Update()
        {
            Console.WriteLine("Updated.........");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Deleted.........");
        }

        public virtual void Insert()
        {
            Console.WriteLine("Inserted.........");

        }
    }


    public class Manager : Employee, IDbFunctions
    {
        public int BASIS, DA, HRA;
        public decimal GROSS;
        
        public override decimal Basic
        {
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


        public Manager(string designation = "manager", string name = "Rahul", decimal basic = 600, short deptNo = 10) : base(name, basic, deptNo)
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
        public override void  Update()
        {
            Console.WriteLine("Manager Updated.........");
        }

        public override void Delete()
        {
            Console.WriteLine("Manager Deleted.........");
        }

        public override void Insert()
        {
            Console.WriteLine("Manager Inserted.........");

        }
    }

    public class GenerelManager : Manager, IDbFunctions
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

        public override void Update()
        {
            Console.WriteLine("Generel Manager Updated.........");
        }

        public override void Delete()
        {
            Console.WriteLine("Generel Manager Deleted.........");
        }

        public override void Insert()
        {
            Console.WriteLine("Generel Manager Inserted.........");

        }
    }

    public class CEO : Employee , IDbFunctions
    {
        public override decimal Basic
        {
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
        public override void Update()
        {
            Console.WriteLine("CEO Updated.........");
        }

        public override void Delete()
        {
            Console.WriteLine("CEO Deleted.........");
        }

        public override void Insert()
        {
            Console.WriteLine("CEO Inserted.........");

        }
    }
}
