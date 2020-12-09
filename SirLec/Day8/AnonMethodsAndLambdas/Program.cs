using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonMethodsAndLambdas
{
    class Program
    {

        //Action
        static void Main1()
        {
            Action o1 = Display;
            o1();
            Action<string> o2 = Display;
            o2("aaa");
            Action<string, int> o3 = Display;
            o3("bbb", 10);
            Console.ReadLine();
        }

        //Func and Predicate
        static void Main2()
        {
            Func<int, int, int> o1 = Add;
            Console.WriteLine( o1(10,20) );

            Func<string, short, int> o2 = DoSomething;
            Console.WriteLine(o2("",0));

            Func<int, bool> o3 = IsEven;
            Console.WriteLine(o3(10));

            Predicate<int> o4 = IsEven;
            Console.WriteLine(o4(10));

            Console.ReadLine();
        }

        //anonymous methods
        static void Main3()
        {
            int i = 10;
            //Action o = delegate { Console.WriteLine("Anonymous method called"); };
            Action o = delegate()
            {
                Console.WriteLine("Display");
                ++i;  //anon methods can access variables defined in the calling code
            };
            o();
            o();
            o();
            o();
            Console.WriteLine(i);

            Func<int, int, int> o2 = delegate (int a, int b)
            {
                return a + b;
            }; 
            Func<int, int, int> o3 = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine(o2(10,20));
            Console.ReadLine();

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
            Console.WriteLine("Display " + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display " + s + i);
        }
    }
}

namespace Lambdas
{
    class Program
    {
        static void Main()
        {
            //x is the parameter of the func
            //=> is the lambda operator
            //x *2 is the return value
            //Func<int, int> o = (x) => x * 2;
            Func<int, int> o = x => x * 2;
            //Func<int, int> o2 = delegate(int a)
            //{
            //    return a * 2;
            //};
            Console.WriteLine(o(10));
            Func<int, int, int> o2 = (a, b) => a + b;
            Console.WriteLine(o2(10,20));

            Func<int, int, int, int> o3 = (a, b, c) =>
            {
                //multiple lines of code
                return a + b + c;
            };

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
            Console.WriteLine("Display " + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display " + s + i);
        }
    }
}

