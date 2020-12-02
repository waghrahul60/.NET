using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass o = new DerivedClass();
            //o.Display1();
            //o.Display1("Rahul");
            //o.Display2();
            o.Display3();
            Console.ReadLine();
        }

        static void Main1()
        {
            //Late Binding
            //declare reference to base class
            BaseClass o;
            o = new BaseClass();
            o.Display2();// Dynamic dishpach | V taable
            o.Display3();
            Console.WriteLine();
            
            o = new DerivedClass();

            o.Display2(); //non virtual Function | Depends on how you declare the object | Early Binding
            o.Display3(); //Virtual Function | depends on what memeory it pointing to | Late Binding
            Console.WriteLine();

            o = new SubDerived();
            o.Display2();
            o.Display3();
            Console.WriteLine();

            o = new SubSubDerived();
            o.Display2();
            o.Display3();
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
        // Overloading the method in derived class
        public void Display1(string s)
        {
            Console.WriteLine("Derived Display1");
        }

        //Hiding the method in derived class
        public new void Display2()
        {
            Console.WriteLine("Derived Display2");
        }

        //Overriding the method in derived class // this is also a virtual function
        public override void Display3()
        {
            Console.WriteLine("Derived Display3");
        }
    }
    public class SubDerived : DerivedClass
    {
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived Display3");
        }
    }
    public class SubSubDerived : SubDerived
    {
        public void Display3()
        {
            Console.WriteLine("SubSubDerived Display3");
        }
    }
}

namespace InheritanceExample2
{
    class Program
    {
        static void Main2()
        {
            // AbstractClass boj = new AbstractClass();
            DerivedClass OBJ = new DerivedClass();
        }
    }
    public abstract class AbstractClass
    {
        public void Display()
        {
            Console.WriteLine("Display from abstract");
        }
    }

    public class DerivedClass : AbstractClass
    {
        public void Show()
        {
            Console.WriteLine("Show from Derived");
        }

    }
    public abstract class AbstractClass2
    {
        public abstract void Display();

        public abstract void Show();

    }
    public class class2 : AbstractClass2
    {
        public override void Display()
        {
            Console.WriteLine("Display");
        }

        public override void Show()
        {
            throw new NotImplementedException();
        }
    }
}