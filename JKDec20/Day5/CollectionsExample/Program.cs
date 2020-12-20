using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
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

            foreach (object  o in objArrayList)
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
            //Hashtable objDictionary = new Hashtable();
            SortedList objDictionary = new SortedList();\
            objDictionary.Add(10, "abc");
            objDictionary.Add(20, "pqr");
            objDictionary.Add(30, "xyz");

            objDictionary[30] = "new value";
            objDictionary[40] = "aaaaaaa";

            objDictionary.Remove(2);

            Console.WriteLine(objDictionary.GetByIndex(0));

            //ArrayList objKeys =(ArrayList) objDictionary.GetKeyList();

            //TO DO : Try the Dictionary methods


            Console.WriteLine();
            foreach (DictionaryEntry de in objDictionary)
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
            foreach (int x in objList)
            {
                Console.WriteLine(x);
            }
        }
        static void Main5()
        {
            SortedList<int, string> objDictionary = new SortedList<int, string>();
            objDictionary.Add(10, "aaa");
            objDictionary[20] = "bb";

            foreach ( KeyValuePair<int,string> kvp in objDictionary)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value);
            }
        }
        //TO DO --> try Stack<T> and Queue<T>

        static void Main6()
        {
            List<Employee> objEmps = new List<Employee>();
            //Employee obj = new Employee();
            //obj.EmpNo = 1;
            //obj.Name = "V";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;
            //objEmps.Add(obj);

            //object initializer
            objEmps.Add(new Employee { EmpNo = 1, Name = "V", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee { EmpNo = 2, Name = "S", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee { EmpNo =3, Name = "H", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee { EmpNo = 4, Name = "A", Basic = 12345, DeptNo = 10 });
            objEmps.Add(new Employee(5,"new"){ Basic = 12345, DeptNo = 10 });


            foreach (Employee obj in objEmps)
            {
                Console.WriteLine(obj.Name);
            }
        }
        static void Main7()
        {
            SortedList<int, Employee> objEmps = new SortedList<int, Employee>();
            objEmps.Add(1,new Employee { EmpNo = 1, Name = "V", Basic = 12345, DeptNo = 10 });
            objEmps.Add(2, new Employee { EmpNo = 2, Name = "S", Basic = 12345, DeptNo = 10 });
            objEmps.Add(3, new Employee { EmpNo = 3, Name = "H", Basic = 12345, DeptNo = 10 });
            objEmps.Add(4, new Employee { EmpNo = 4, Name = "A", Basic = 12345, DeptNo = 10 });

            foreach (KeyValuePair<int,Employee> kvp in objEmps)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value.Name);
            }

        }
        static void Main()
        {
            //List<Employee> objEmps = new List<Employee>();
            Employees objEmps = new Employees();
            
        }
    }
    public class Employees : List<Employee>
    {

    }

    //TO DO : Try creating Employees class based on SortedList<...>
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name{ get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }

        public Employee(int EmpNo=1, string Name="aaa")
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
        }
    }
}


/*
 Boxing 

int i = 100;
object o;
o = i; //BOXING

//storing a value type into a reference type is called BOXING a value type

//the value type on the stack is copied to the heap and a ref to that is created.


Unboxing

int j;
j = (int)o; //UNBOXING
//Getting the value from a  boxed reference type is called Unboxing

//the boxed value is copied from the heap to the stack






 */