using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Reference Types - All classes and their variants are Ref Types
All classes, interfaces, delegates, arrays, object class, and the string class are reference types
Memory for the object is allocated on the Heap, the reference is allocated on the stack

Value Types - All structs and their variants are Value Types
All structs and enums are Value Types
Memory allocation is on the stack
 */
namespace RefAndValueTypes
{
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;
            o1 = o2;
            o2.i = 300;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
            //300,300
             Console.ReadLine();
        }

        static void Main2()
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1);
            Console.WriteLine(o2);

            Console.ReadLine();
        }

        static void Main3()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
          
            //300,300
            //200,300

            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }

        static void Main4()
        {
            int i;
            int j;

            Init(out i, out j);
            //Swap(ref i, ref j);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }
        static void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;

        }

        //out is similar to ref - changes made in func reflect back in calling code
        static void Init(out int i, out int j)
        {
            //the initial value is discarded
            // Console.WriteLine(i);
            i = 100;
            j = 200;
            //out variables MUST be initialized in the function
        }

        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);

            Console.WriteLine(o.i);
            Console.ReadLine();
        }
        //reference type - changes made in func reflect back in calling code
        static void DoSomething1(Class1 obj)
        {
            obj.i = 200;
        }
        //reference type - if new object is created, the calling code(Main) does not point to the new object
        static void DoSomething2(Class1 obj) //obj = o
        {
            
            obj = new Class1();
            obj.i = 200;
        }
        //reference type passed as ref - if new object is created, the calling code(Main) points to the new object
        static void DoSomething3(ref Class1 obj) //obj = o
        {
            obj = new Class1();
            obj.i = 200;
        }
        static void DataTypes()
        {
            byte b1;
            sbyte b2;
            char ch;
            short sh1;
            ushort sh2;
            int i1; //System.Int32 //4
            uint i2;//System.UInt32 //4
            long l1;
            ulong l2;
            float f;
            double d;
            decimal d2;
            bool b;

            string s;
            object o;

        }
    }

    public class Class1
    {
        public int i;
    }
}
