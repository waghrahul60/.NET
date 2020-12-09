﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Implicit Variables
namespace LanguageFeatures1
{
    class Program
    {
        static void Main1()
        {
            int i;
            var i2 = 100;  //implicit variable
            var i3 =(short) 100;  //implicit variable
            //used only for local variables
            //cant be used for class level vars,fn params and return types
            //i2 = 200;
            Console.WriteLine(i2.GetType().ToString());
            Console.ReadLine();

           
        }
    }
}
//object initializers
namespace LanguageFeatures2
{
    public class Class1
    {
        public int i, j;
        public Class1()
        {
            i = 100;
            j = 200;
        }
        public Class1(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
    class Program
    {
        static void Main1() //OBJECT INITIALIZERS
        {
            
            Class1 o = new Class1();
            o.i = 123;
            o.j = 456;

            Class1 o2 = new Class1() { i = 123, j = 456 };  // Object Initializer
            Class1 o3 = new Class1 { i = 123, j = 456 };  // Object Initializer
            Class1 o4 = new Class1(10, 20) { i = 123, j = 456 };  // Object Initializer

        }
    }
}
//anonymous type
namespace LanguageFeatures3
{
    class Program
    {
        static void Main1() // ANONYMOUS TYPES
        {
            //Class1 o = new Class1();
            //Class1 o3 = new Class1 { i = 123, j = 456 };
            var myCar = new { Color = "Red", Model = "Ferrari", Version = "V1", CurrentSpeed = 75 };

            var myCar2 = new { Color = "Blue", Model = "Merc", Version = "V2" };

            Console.WriteLine("{0} {1} {2} {3}", myCar.Color, myCar.Model, myCar.Version, myCar.CurrentSpeed);

            Console.WriteLine(myCar.GetType().ToString());
            Console.WriteLine(myCar2.GetType().ToString());

            Console.ReadLine();
        }

    }
}
//extension method
namespace LanguageFeatures4
{
    class Program
    {
        static void Main1()
        {
            int i = 123;
            i.Display();
            
            //i = i.Reverse();  //extension method example
            string s = "aaa";
            s.Show();
            s.Method2(10,20);
            Console.ReadLine();
        }
        static void Main2()
        {
            int i = 123;
           
            i.Display();
            MyExtensionMethods.Display(i);
            i.ExtMet();

            string s = "aaa";
            s.Show();
            s.ExtMet();

            MyExtensionMethods.Show(s);
            //s.Method2(10, 20);
            Console.ReadLine();
        }

        static void Main3()
        {
            ClsMaths objClsMaths = new ClsMaths();

            Console.WriteLine(   objClsMaths.Subtract(20,10));
            Console.ReadLine();
        }
        static int Reverse(int i)
        {

            int reverse = 0;
            ///code here
            ///
            return reverse;
        }
    }
    public static class MyExtensionMethods
    {
        //extension method written for the base class is also available for the derived classs
        public static void ExtMet(this object i) 
        {
            Console.WriteLine(i);
        }
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string s)
        {
            Console.WriteLine(s);
        }
        public static void Method2(this string s, int i, int j)
        {
            Console.WriteLine(s);
        }

        //if you define an extension method for an interface, 
        // it is also available to all classes that implement that interface
        public static int Subtract(this IMathOperations i, int a, int b)
        {
            return a - b;
        }
    }


    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
//partial classes
namespace LanguageFeatures5
{
    //PARTIAL CLASSES

    //partial classes must be in the same assembly
    //partial classes must be in the same namespace
    //partial classes must have the same name


    public partial class Class1
    {
        public int i;
    }
   
    public class Program
    {
        public static void Main1()
        {
            Class1 o = new Class1();
            
           
        }
    }
}
namespace LanguageFeatures5
{
    public partial class Class1
    {
        public int j;
    }
}

//partial methods
namespace PartialMethods
{
    public class MainClass
    {
        public static void Main()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            //.....
            Validate();
            return isValid;
        }
    }

    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

}
