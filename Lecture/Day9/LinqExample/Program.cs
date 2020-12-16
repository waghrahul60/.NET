using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
   
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void Main1()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            var emps = from emp in lstEmp select emp;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (Employee emp  in emps)
            {
                Console.WriteLine( emp.Name );
            }

            Console.ReadLine();

        }
        static void Main2()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            var emps = from emp in lstEmp select emp.Name;
            //var emps = from emp in lstEmp select emp.Basic;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            Console.ReadLine();

        }
        static void Main3()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            
            var emps = from emp in lstEmp select new { emp.Name, emp.Basic };

            //var emps = from emp in lstEmp select emp.Basic;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }

        static void Main4()
        {
            AddRecs();


            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;
            //var emps = from emp in lstEmp
            //           where emp.Name.StartsWith("V")
            //           select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           orderby emp.Name ascending
            //           select emp;

            var emps = from emp in lstEmp
                       orderby emp.DeptNo, emp.Name descending
                       select emp;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
      
        static void Main6()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select new { dept.DeptName, emp.Name };

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }

       static Employee GetEmployees(Employee obj)
        {
            return obj;
        }

        static void Main7()
        {
            AddRecs();

            // var emps = from emp in lstEmp select emp;

            //passing function as a parameter to Select
            //var emps = lstEmp.Select(GetEmployees);

            //passing anon method as a parameter to Select
            //var emps = lstEmp.Select(delegate(Employee obj)
            //{
            //    return obj;
            //});

            //using a lambda instead of anon method
            var emps = lstEmp.Select(emp=>emp);

            //longer way
            //Func<Employee, Employee> o = e => e;
            //var emps = lstEmp.Select(o);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();
        }

        static void Main()
        {

            AddRecs();
            //var emps = lstEmp.Where(emp => emp.Basic > 11000);

            //var emps = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp);
            //var emps = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => new { emp.Name, emp.Basic });
            
            var emps3 = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 11000);
            var emps4 = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 11000);

            var emps = lstEmp.OrderBy(emp => emp.Name).Where(emp => emp.Basic);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + " "+emp.Basic);
            }

            Console.ReadLine();
        }

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}
