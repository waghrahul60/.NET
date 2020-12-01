using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            CLass1 o1 = new CLass1();
            CLass1 o2 = new CLass1();
            o1.i = 200;
            o2.i = 500;
            o1.Display();
            CLass1.s_i = 124;
            Console.WriteLine(CLass1.s_i);
            CLass1.s_Display();

           
            Console.ReadLine();
        }
    }

    public class CLass1
    {
        static CLass1()
        {
            Console.WriteLine("ststic cons");
            s_i = 20;
        }

        public int i;
        //static variable - single copy of thaat vaariable

        public static int s_i;

        // non static method
        public void Display()
        {
            Console.WriteLine("disp");
            Console.WriteLine(i);
            Console.WriteLine(s_i);
        }

        //static method -> can be access directly without creating object 
        public static void s_Display()
        {
            Console.WriteLine("Static disp");
            //Console.WriteLine(i); We have multipal vaalues of i
            //it not understand which value of i you are accessing you can write o1.i
            Console.WriteLine(s_i);
        }

        //property validations
        private int p1;
        public int P1
        {
            set 
            {
 
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    Console.WriteLine("invilid value");
                }

            }
            get 
            {
                return p1;
            }
        }


        //staatic property - single copy with validation
        private static int p2;
        public static int P2
        {
            set 
            {
               
                if (value < 100)
                {
                    p2 = value;
                }
                else
                {
                    Console.WriteLine("invilid value");
                }

            }
            get { 
                return p2;
            }
        }
    }


    public static class s_Class1
    {
        // can olny have ststic members
        // cannot be instantiated(We can not create object of that class)
        // cannot bc used as a base class(You can not inherite this class)
        // Console class is a static class
        // Classess have general purpose functions we create Static classess
        static int a;
    }
}

// Constructor -> initilise members //call when object get created
// Static Constructor -> initilise ststic members //call only ones in program
// Static Constructor is called when 1st time class loaded into memory
// when class get loaded into memory ?
// either 1st object will be created
//  or you access the static member of class
// It implicitly called, when class loaded in memory
// we can't pass any parameters into it
// therefor we can not overloaad sttic constructor
// Implicitly privaate :- called within the class Cannot call from outside the class

// we have both constructors
// when first obj create both constructors get called
// static const get call then normal constructor get called