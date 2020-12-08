using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypes
{
    class Program
    {
        static void Main1()
        {
            //MyPoint p;
            //p.X = 123;
            //p.Y = 456;
            MyPoint p = new MyPoint();
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);

            //int i=0;
            //int i = new int();
            //Console.WriteLine(i);
            Console.ReadLine();
        }
        static void Main()
        {
            // Display1(0);
            Display2(TimeOfDay.Morning);
            Console.ReadLine();
        }
        static void Display1(int t)
        {
            if (t == 0)
                Console.WriteLine("Good Morning");
            else if (t == 1)
                Console.WriteLine("Good Afternoon");
            else if (t == 2)
                Console.WriteLine("Good Evening");
            else if (t == 3)
                Console.WriteLine("Good Night");
        }
        static void Display2(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
                Console.WriteLine("Good Morning");
            else if (t == TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t == TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if (t == TimeOfDay.Night)
                Console.WriteLine("Good Night");
        }
    }
    
    public enum TimeOfDay //: long
    {
        Morning = 100 ,
        Afternoon =200,
        Evening,
        Night
    }
    public struct MyPoint
    {

        public MyPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X, Y;
    }
    //structs are Value Types - stored on stack. Faster than Heap operations
    //No Inheritance allowed in structs
    //Parameterless constructor not allowed in structs


}
