using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Delegate Hierarchy
//Object
//Delegate
//MultiCastDelegate
//Del1
namespace DelegatesExample
{
    //step 1 : create a delegate class having the same signature as the function to call

    public delegate void Del1();

    public delegate int DelAdd(int a, int b);
    class Program
    {
        static void Main1()
        {
            //Display();
            //step 2 : create a delegate object passing the function name as a parameter.
            Del1 objDel = new Del1(Display);

            //step 3 : call the func via the delegate object
            objDel();

            Console.ReadLine();
        }
        static void Main2()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();

            objDel = new Del1(Show);
            objDel();
            Console.ReadLine();
        }

        static void Main3()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += new Del1(Show);
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += new Del1(Display);
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= new Del1(Display);
            objDel();

            Console.ReadLine();
        }

        static void Main4()
        {
            Del1 objDel;
            objDel = Display;
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += Show;
            objDel();


            Console.WriteLine();
            Console.WriteLine();
            objDel += Display;
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= Display;
            objDel();

            Console.ReadLine();
        }

        static void Main5()
        {
            Del1 objDel = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show), new Del1(Display));
            objDel();

            Console.WriteLine();
            Console.WriteLine();
            //objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            objDel();

            Console.ReadLine();
        }

        static void Main6()
        {
            //DelAdd objDelAdd = new DelAdd(Add);
            DelAdd objDelAdd = Add;

            Console.WriteLine(objDelAdd(10,20));
            // TO DO : Try multicast delegates with parameters and a return value

            Console.ReadLine();
        }

        static void Main7()
        {
            //DelAdd objDelAdd = new DelAdd(Add);
            //DelAdd objDelAdd = Class2.Add;   //if static
            Class2 objCls2 = new Class2();
            DelAdd objDelAdd = objCls2.Add;   //if not static


            Console.WriteLine(objDelAdd(10, 20));
            // TO DO : Try multicast delegates with parameters and a return value

            Console.ReadLine();
        }
        static void Main()
        {
            //Console.WriteLine(PassMethodToCallAsAParameter(new DelAdd(Add), 20, 10));
            Console.WriteLine(PassMethodToCallAsAParameter(Add, 20, 10));
            Console.WriteLine(PassMethodToCallAsAParameter(Subtract, 20, 10));
            Console.WriteLine(PassMethodToCallAsAParameter(Multiply, 20, 10));
            Console.ReadLine();
        }
        static void Display()
        {
            Console.WriteLine("disp");
        }
        static void Show()
        {
            Console.WriteLine("show");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int PassMethodToCallAsAParameter(DelAdd objDelAdd,int a, int b)//objDelAdd = Add, a = 20, b = 10
        {
            return objDelAdd(a, b);
        }
    }
    public class Class2
    {
        public  int Add(int a, int b)
        {
            return a + b;
        }
    }
}

