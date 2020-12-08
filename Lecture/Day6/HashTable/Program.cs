
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main1()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(10);
            objArrayList.Add("aaa");
            objArrayList.Add(10.5);
            objArrayList.Add(true);

            Console.WriteLine(objArrayList.Count);
            objArrayList.Remove("aaa");
            objArrayList.RemoveAt(0);

            foreach (object o in objArrayList)
            {
                Console.WriteLine(o);
            }
            //objArrayList.AddRange(obj2)

            //objArrayList.Capacity = 100;
            //objArrayList.TrimToSize()

            //objArrayList.Clear
            // bool isThere = objArrayList.Contains(10);
            //objArrayList.CopyTo(arr)
            //objArrayList.Insert(0, "aa");
            // objArrayList.InsertRange
            //objArrayList.RemoveRange
            //object[] arr = objArrayList.ToArray();
            //objArrayList.BinarySearch
            //objArrayList.IndexOf
            //objArrayList.LastIndexOf

            Console.ReadLine();
        }

        static void Main2()
        {
            SortedList objDictionary = new SortedList();
            objDictionary.Add(1, "abc");
            objDictionary.Add(2, "pqr");
            objDictionary.Add(3, "zyz");

            objDictionary[3] = "new value";
            objDictionary[4] = "aaaaa";


            ArrayList objkeys = (ArrayList)objDictionary.GetKeyList();
            

            foreach(DictionaryEntry de in objDictionary)
            {
                Console.WriteLine(de.Key);
                Console.WriteLine(de.Value);
                
            }

            Console.ReadLine();
         }


        static void Main3()
        {
            Stack objStack = new Stack();
            objStack.Push(1000);
            objStack.Push(2000);
            objStack.Push(3000);

            Console.WriteLine(objStack.Peek());

            Console.WriteLine(objStack.Pop());


            Queue objQ = new Queue();
            objQ.Enqueue(1111);
            Console.WriteLine(objQ.Peek());
            Console.WriteLine(objQ.Dequeue());
        }

        static void Main4()
        {
            List<int> objList = new List<int>();
            objList.Add(10);

            foreach(int x in objList)
            {
                Console.WriteLine(x);
            }

        }
        /*static void Main()
        {
            SortedList<int, string> objDictonary = new SortedList<int, string>()
           {
             //  objDictonary.Add(10, "aaaa");
            // objDictonary[20] = "bb";

           }
        }*/
        static void Main()
        {
            List<Employee> objEmps = new List<Employee>();

            Employee obj = new Employee();
            obj.EmpNo = 1;
            obj.Name = "Rahul";
            obj.Basic = 2500;
            obj.DeptNo = 10;
            objEmps.Add(obj);

            objEmps.Add(new Employee { EmpNo = 2, Name = "Rahul", Basic = 2500000, DeptNo = 20 });
            objEmps.Add(new Employee { EmpNo = 2, Name = "Kalpesh", Basic = 2500000, DeptNo = 20 });
            objEmps.Add(new Employee { EmpNo = 2, Name = "Mohit", Basic = 2500000, DeptNo = 20 });
            objEmps.Add(new Employee { EmpNo = 2, Name = "Sudya", Basic = 2500000, DeptNo = 20 });
            objEmps.Add(new Employee(5, "new") { Basic = 12345, DeptNo = 10 });

            // if you have a constructor then cll it
            // or call a object initilizer

            foreach(Employee a in objEmps)
            {
                Console.WriteLine(a.Name);
            }

            Console.ReadLine();
        }

    }

    public class Employees : List<Employee>
    {

    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string  Name { get; set; }

        public decimal Basic { get; set; }

        public short DeptNo { get; set; }

        public Employee(int EmpNo = 1, string Naame = "lsfjhgk")
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
        }

    }
}
