using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnoMethodsAndLambdas
{
    class Program
    {
        static void Main1(string[] args)
        {
            Action o1 = Display;
            o1();
            

            Action<string> o2 = Display;
            o2("aaa");

            Action<string, int> o3 = Display;
            o3("bbb", 10);
            Console.ReadLine();
        }

        //func and predicates
        static void Main2()
        {
            Func<int, int, int> o1 = Add;
            Console.WriteLine(o1(10,20));

            Func<string, short, int> o2 = DoSomething ;
            Console.WriteLine(o2("", 20));

            Func<int, bool> o3 = IsEven;
            Console.WriteLine(o3(10));

            Predicate<int> o4 = IsEven;
            Console.WriteLine(o4(10));
            Console.ReadLine();
        }


        static void Main3()
        {
            int i = 10;
            //Action o = delegate { Console.WriteLine("Anonymous method call"); };
            Action o = delegate ()
                {
                    Console.WriteLine("Display");
                    ++i; //anon method can access variables define in calling code
                };
            o();
            Console.WriteLine(i);

            Func<int, int,int> o2 = delegate (int a, int b)
             {
                 return a + b;
             };
            Console.WriteLine(o2(10,20));

            Func<int, int, int> o3 = delegate (int a, int b)
            {
                return a - b;
            };
            Console.WriteLine(o2(30, 20));

            Console.ReadLine();
        }

        static  bool IsEven(int a)
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

        static void Display(string s,int i)
        {
            Console.WriteLine("Display");
        }
    }
}
