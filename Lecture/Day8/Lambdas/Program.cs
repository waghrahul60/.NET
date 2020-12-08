using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> o = x => x * 2;
            Console.WriteLine(o(10));

            Func<int, int, int> o2 = (a,b) => ( a + b);
            Console.WriteLine(o2(10,20));

            Func<int, int, int, int> o3 = (a, b, c) =>
            {
                //Multiple lines of code
                return a + b + c;
            };
            Console.WriteLine(o2(10, 20));

            Console.ReadLine();
        }

        static int MakeDouble(int a)
        {
            return a * 2;
        } 
        static bool IsEven(int a)
        {
            return a % 2 == 0;
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int DoSomething(string a, short b)
        {
            return 1;
        }
        static void Display()
        {
            Console.WriteLine("Display");
        }

        static void Display(string s)
        {
            Console.WriteLine("Display");
        }

        static void Display(string s, int i)
        {
            Console.WriteLine("Display");
        }
    }
}
