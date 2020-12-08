using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Infividually Add Values
            /*MyPoint p;
            p.X = 1;
            p.Y = 2;*/

            //Call Non paaraa Constructor

            //int i = 0;
            //int i = new int();

            Display2(TimeOfDay.Afternoon);
            MyPoint p = new MyPoint();
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);

            Console.ReadLine();
        }

        static void Display1(int t)
        {
            if(t == 0)
            {
                Console.WriteLine("Good Morning");
            }else if (t == 2)
            {
                Console.WriteLine("Good Afternun");
            }
            else if (t == 3)
            {
                Console.WriteLine("Good Morning");
            }
            else if (t == 4)
            {
                Console.WriteLine("Good Morning");
            }

        }

        static void Display2(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
            {
                Console.WriteLine("Good Morning");
            }
            else if (t == TimeOfDay.Afternoon)
            {
                Console.WriteLine("Good Afternun");
            }
            else if (t == TimeOfDay.Evening)
            {
                Console.WriteLine("Good Morning");
            }
            else if (t == TimeOfDay.Night)
            {
                Console.WriteLine("Good Morning");
            }

        }
    }

    //int TimeDay
    
    public enum TimeOfDay //:long
    {
        Morning = 100,
        Afternoon,
        Evening,
        Night
    }
    public struct MyPoint
    {
        public int X, Y;
        /*public MyPoint(int x, int y)
        {

        }*/
    }
}
