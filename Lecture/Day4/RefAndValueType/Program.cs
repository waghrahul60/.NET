using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValueType
{
    class Program
    {
        static void Main1(string[] args)
        {
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200; 
            o1 = o2;  // o1 points to o2 and old memory becoms garbage memory
            o2.i = 300;
            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2; // Normal integar
            o2 = 300;
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }
        static void Main3(string[] args)
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2; //String in immutable in c#
            o2 = "300";
            Console.WriteLine(o1);
            Console.WriteLine(o2);
            Console.ReadLine();
        }

        static void Main48(string[] args)
        {
            int i = 1;
            int j = 2;

            Swap(ref i, ref j);  // Call by Reference
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
        

        static void Main5()
        {
            int i ;
            int j  ;
            Init(out i, out j);
           // Swap2(ref i, ref j);  // Call by Reference
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();

        }
        static void Swap2(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        static void Init(out int i, out int j)
        {
            i = 100;
            j = 200;
        }
        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            //DoSomething(o);
            //DoSomething2(o);
            DoSomething3(ref o);


            Console.WriteLine(o.i);
            Console.ReadLine();

        }
        static void DoSomething(Class1 obj) // obj = o
        {
            obj.i = 200;
        }
        static void DoSomething2(Class1 obj) // obj = o
        {
            obj = new Class1(); // obj => New location
            obj.i = 200;
        }
        static void DoSomething3(ref Class1 obj) // obj = o
        {
            obj = new Class1(); // obj => New location
            obj.i = 200;
        }
        //Try Out

        static void DataTypes()
        {
            byte b1;
            sbyte b2;
            char ch; // 2 byte becoz unicode (unicode is 2 byte value)
            short sh1;
            ushort sh2;
            int i1; //System.Int32 //4
            uint i2;//System.UInt32 //4
            long l1;//System.Int64 //8
            ulong l2;//System.UInt64 //4
            float f; //System.single //4 byte
            double d;
            decimal d1;// System.decimal
            bool n; //System.boolean - 1 byte
            string s;//System.Siring
            object o;//System.Object
        }
    }


    public class Class1
    {
        public int i;
    }
}
