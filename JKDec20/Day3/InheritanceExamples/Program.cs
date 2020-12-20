using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples
{
    class Program
    {
        static void Main1()
        {
            int i;
            i =int.Parse( Console.ReadLine());

            decimal d;
            d = decimal.Parse(Console.ReadLine());

            i = Convert.ToInt32(Console.ReadLine());
        }
    }
}

//constructors in inheritance
namespace InheritanceExamples2
{

    class Program
    {
        static void Main1()
        {
            //DerivedClass o = new DerivedClass();
            DerivedClass o2 = new DerivedClass(123, 456);
            Console.ReadLine();
        }
    }
    public class BaseClass
    {
        public int i;
        public BaseClass()
        {
            Console.WriteLine("base class no param cons");
            i = 10;
        }
        public BaseClass(int i)
        {
            Console.WriteLine("base class int cons");
            this.i = i;
        }
    }
    public class DerivedClass : BaseClass
    {
        public int j;
        public DerivedClass()
        {
            Console.WriteLine("derived class no param cons");
            //i = 10;
            j = 20;
        }
        public DerivedClass(int i, int j) : base(i)
        {
            Console.WriteLine("derived class int,int cons");
            //this.i = i;
            this.j = j;
        }
    }
}

//overload, hiding, overriding
namespace InheritanceExamples3
{

    class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
           

            //o.Display1();
            //o.Display1("a");

            //o.Display2();
            o.Display3();

            Console.ReadLine();
        }

        static void Main()
        {
            //Late Binding
            //declare a reference to the Base CLass
            BaseClass o;
            o = new BaseClass();

            o.Display2(); //non virtual function
            o.Display3(); //virtual function

            Console.WriteLine();

            o = new DerivedClass();
            o.Display2(); //non virtual function
            o.Display3(); //virtual function

            Console.WriteLine();

            o = new SubDerivedClass();
            o.Display2(); //non virtual function
            o.Display3(); //virtual function
            Console.WriteLine();

            o = new SubSubDerivedClass();
            o.Display2(); //non virtual function
            o.Display3(); //virtual function

            Console.ReadLine();
        }
      
    }
    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("Base Display1");
        }

        public void Display2()
        {
            Console.WriteLine("Base Display2");
        }

        public virtual void Display3()
        {
            Console.WriteLine("Base Display3");
        }
    }
    public class DerivedClass : BaseClass
    {

        //overloading the method in the derived class
        public void Display1(string s)
        {
            Console.WriteLine("Derived Display1");
        }

        //hiding the method in the derived class
        public new void Display2()
        {
            Console.WriteLine("Derived Display2");
        }

        //overriding the base class method
        public override void Display3()
        {
            Console.WriteLine("Derived Display3");
        }
    }
   
    public class SubDerivedClass : DerivedClass
    {
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived Display3");
        }
    }

    public class SubSubDerivedClass : SubDerivedClass
    {
        public new void Display3()
        {
            Console.WriteLine("SubSubDerived Display3");
        }
    }
}

/*
 - overload the base class method
- hide the base class method
- override the base class method
common --- derived class method has the same name as the base class method

different
in overloading the signature will be diff
hiding and overriding will have same signature as the base class

difference between hiding and overriding
only a virtual method can be overridden, ANY method could be hidden
 
*/


namespace InheritanceExamples4
{
    class Program
    {
        static void Main()
        {
            //AbstractClass obj = new AbstractClass();
            DerivedClass obj = new DerivedClass();
            obj.Display();
            Console.ReadLine();
        }
    }

    public abstract class AbstractClass
    {
        public void Display()
        {
            Console.WriteLine("display from abs");
        }

    }

    public class DerivedClass : AbstractClass
    {
        public void Show()
        {
            Console.WriteLine("sjhow");
        }
    }
    public abstract class AbstractClass2
    {
        public abstract void Display();
        public abstract void Show();

    }
    public class Class2 : AbstractClass2
    {
        public override void Display()
        {
            Console.WriteLine("display");
        }

        public override void Show()
        {
            Console.WriteLine("show");
        }
    }
}


/*
 			    Can Instantiate		Can Inherit from
Abstract Class		NO			        YES
Sealed Class		YES			        NO


 * */

//TO DO : Create a sealed class


