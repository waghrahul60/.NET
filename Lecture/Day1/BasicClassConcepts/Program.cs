using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BasicClassConcepts
{
    class Program
    {
        static void oldMain()
        {
            //class2
            //BasicClassConcepts.class2
            //n2.class2
            //System.Data.DataSet
            // n2.n3.class4;
            //System.Console.WriteLine("Hello World");
            Console.WriteLine("aa");
            System.Console.ReadLine();

            System.Data.DataSet ds = new System.Data.DataSet();
            DataSet qwe = new DataSet();
        }

        static void Main()
        {
            //Class1.Display()  You can not colled that
            class1 o; // o is a reference of type Class1
            o = new class1(); // Allocate memory for an object of type Class1 and make o point to it

            //class1 o = new class1();
            o.Display();
            o.Display("Rahul");
            
            //Positional parameters
            Console.WriteLine(o.Add(10, 20, 30, 40));
            Console.WriteLine(o.Add(10, 20, 30));
            Console.WriteLine(o.Add(10, 20));
            Console.WriteLine(o.Add(10));
            Console.WriteLine(o.Add());

            // Named Parametsre
            Console.WriteLine(o.Add(d: 40));
            Console.WriteLine(o.Add(c: 30));
            Console.WriteLine(o.Add(d: 40, c: 30));


            //Add2
            //Console.WriteLine(o.Add2(d: 40));
            Console.WriteLine(o.Add2(d: 40, a: 40, b: 40, c: 40));



            Console.ReadLine();

        }
    }
    public class class1
    {
        public void Display()
        {
            System.Console.WriteLine("Display");
        }

        //function Overloading
        public void Display(String s)
        {
            //Console.WriteLine("\\n");
            System.Console.WriteLine("Display \n " + s);
        }

        //Optional parameters with Default values
        //If You are giving Optional parametr All Parameters to It's right all are optional (Positional parameters)
        public int Add(int a= 0, int b= 0, int c= 0, int d= 0) //Default parameters (another way of Overloading)
        {
            return a + b + c + d;
        }
        //public int Add(int a, int b, int c)
        //{
        //    return a + b + c;
        //}
        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}

        public int Add2(int a , int b , int c , int d ) 
        {
            return a + b + c + d;
        }
    }
}

namespace n2
{
    class C3
    {

    }
    class class2
    {

    }
    namespace n3
    {
        class class4
        {

        }
    }
}