using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void Del1(int a);
        public delegate int DelAdd(int a,int b);


        static void Main1(string[] args)
        {
            //Display
            Program a = new Program();
            Del1 objDel = new Del1(a.Display2);
            objDel(10);
            
            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            //Display
            Program a = new Program();
            Del1 objDel = new Del1(Display);
            objDel(10);

            objDel = new Del1(Show);
            objDel(10);

            Console.ReadLine();
        }

        static void Main3(string[] args)
        {
            //Display
            Program a = new Program();
            Del1 objDel = new Del1(Display);
            objDel(10);
            Console.WriteLine("======================");
            objDel += new Del1(Show);
            objDel(10);

            Console.WriteLine("======================");
            objDel -= new Del1(Show);
            objDel(10);

            Console.ReadLine();
        }
        static void Main4(string[] args)
        {
            //Display
            Program a = new Program();
            Del1 objDel = new Del1(Display);
            objDel(10);
            Console.WriteLine("======================");
            objDel += new Del1(Show);
            objDel(10);

            Console.WriteLine("======================");
            objDel += new Del1(Display);
            objDel(10);

            Console.WriteLine("======================");
            objDel -= new Del1(Display);
            objDel(10);

            Console.ReadLine();
        }

        static void Main5(string[] args)
        {

            Del1 objDel;
            objDel = Display;
            objDel(10);
            Console.WriteLine("======================");
            objDel += Show;
            objDel(10);

            Console.WriteLine("======================");
            objDel += Display;
            objDel(10);

            Console.WriteLine("======================");
            objDel -= Display;
            objDel(10);

            Console.ReadLine();
        }

        static void Main6(string[] args)
        {

            //Delegate.CreateDelegate
            //Delegate.Combine  +=
            Del1 objDel= (Del1)Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            objDel(10);
            Console.WriteLine("======================");

            objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel(10);
            Console.WriteLine("======================");

           // objDel = (Del1)Delegate.RemoveAll()

            Console.ReadLine();
        }

        static void Main7(string[] args)
        {
            //DelAdd objDelAdd = new DelAdd(Add);
            DelAdd objDelAdd = Add;
            objDelAdd = Substract;
            Console.WriteLine(objDelAdd(10,20));
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PassMethodeToCallAsParameter(Add, 20, 10));
            Console.WriteLine(PassMethodeToCallAsParameter(Substract, 20, 10));
            Console.WriteLine(PassMethodeToCallAsParameter(Multiply, 20, 10));
            Console.WriteLine(PassMethodeToCallAsParameter(new DelAdd(Add), 20, 50));


            Console.ReadLine();
        }


        static void Display(int a)
        {
            Console.WriteLine(a);
            Console.WriteLine("Display");
        }

        void Display2(int a)
        {
            Console.WriteLine(a);
            Console.WriteLine("Display 2");
        }
        static void Show(int a)
        {
            Console.WriteLine(a);
            Console.WriteLine("Show");
        }

        static int Add(int a,int b)
        {
            Console.WriteLine("Add Call");
            return a + b;
        }

        static int Substract(int a, int b)
        {
            Console.WriteLine("Substract Call");
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            Console.WriteLine("Multi Call");
            return a * b;
        }
        static int PassMethodeToCallAsParameter(DelAdd objDelAdd, int a, int b)
        {
            return objDelAdd(a, b);
        }
    }

    public class Class2
    {
        public static int Add(int a, int b)
        {
            Console.WriteLine("Add Call");
            return a + b;
        }
    }
}
