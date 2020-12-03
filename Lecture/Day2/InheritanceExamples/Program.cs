 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples
{
    class Program
    {
        static void Main1(string[] args)
        {

            // BaseClass o = new BaseClass();
            DerivedClass o = new DerivedClass(); // methods of DerivedClass BaseClass Object class

        }
    }

    public class BaseClass
    {
        public int a;
    }

    public class DerivedClass : BaseClass
    {
        public int b;
    }
}

namespace InheritanceExamples2
{
    //default access specifiers internal
    class Program
    {
        static void Main(string[] args)
        {
            //BaseClass o = new BaseClass();
            AccessApecifiers.BaseClass o = new AccessApecifiers.BaseClass();
            //o.
        }
    }

    /*public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
    }*/

    public class DerivedClass : AccessApecifiers.BaseClass   //BaseClass
    {
        void DoNothing()
        {
            //default access specifiers for members of a class is private
            //this.
            
        }
    }
}

/*
 * Inheritance?
 * in CPP
 * Base class / Parent /Super
 * 
 * Derived Class / Child  /Sub
 * 
 * ========================================
 *   Base
 *     |
 * Derived
 * 
 * ====No multipal inheritance is there====
 * Base Base 
 * ---------
 *     |
 * Derived
 * 
 * 
 * ====Multiple Inheritance=====
 * Base 
 *   |
 * Derived
 *   |
 * SubDerived
 * 
 * Cpp :-
 * class DerivedClass : public BaseClass
 * 
 * .NET :-
 * class DerivedClass : BaseClass
 * 
 * Access specifiers In CPP :-
 * public private protected
 * 
 *  * Access specifiers In .Net :-
 * public, private, protected, internal, protected internal
 * 
 * public => everywhere
 * privte => same class
 * protected => same class, derived class
 * internal => same class, same assembly(same project)
 * protected internal => same class, derived class, same assembly 
 * code reusability
 * 
 * 
 * if you dont give aanything all classes inherited from Object class
 * Boject class is parent of all classes
 */