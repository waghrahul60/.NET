using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces1
{
    class Program
    {
        static void Main1(string[] args)
        {
            Class1 o = new Class1();
            
            //method 1
            o.Insert();
            o.Update();
            o.Delete();

            //method 2
            IDbFunctions oIDb;//Explicitli create the reference
            oIDb = o;
            oIDb.Delete();

            //method 3 //Implicitly create the reference of Interfce
            ((IDbFunctions)o).Delete();

            Console.ReadLine();

        }
    }

    public interface IDbFunctions
    {
        void Insert();

        void Update();

        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class1 => Delete");
        }
        public void Display()
        {
            Console.WriteLine("Class1 => Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 => Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 => Update");
        }
    }
}

namespace Interfaces2
{
    class Program
    {
        static void Main1(string[] args)
        {
            Class1 o1 = new Class1();
            o1.Insert();

            Class2 o2 = new Class2();
            o2.Insert();

            IDbFunctions oIDb;
            oIDb = o1;
            oIDb.Insert();

            oIDb = o2;
            oIDb.Insert();

            Console.ReadLine();
        }
        static void Main2(string[] args)
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();

            InsertMethod(o1);
            InsertMethod(o2);

            Console.ReadLine();
        }
        static void InsertMethod(IDbFunctions oIDb) //Call From Different Assembly
        {
            oIDb.Insert();
            oIDb.Delete();
        }
    }
   

    public interface IDbFunctions
    {
        void Insert();

        void Update();

        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class1 => Delete");
        }
        public void Display()
        {
            Console.WriteLine("Class1 => Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 => Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 => Update");
        }
    }
    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class2 => Delete");
        }
        public void Show()
        {
            Console.WriteLine("Class2 => Show");
        }

        public void Insert()
        {
            Console.WriteLine("Class2 => Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 => Update");
        }
    }
}

namespace Interfaces3
{
    public interface IDbFunctions
    {
        void Insert();

        void Update();

        void Delete();
    }
    public interface IFileFunction
    {
        void Open();
        void Close();
        void Delete();
    }

    //Name And Signature is same then this problem occurs
    public class Class1 : IDbFunctions, IFileFunction
    {
        
        public void Delete()
        {
            Console.WriteLine("Class1 => IDb.Delete");
        }
        public void Display()
        {
            Console.WriteLine("Class1 => IDb.Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 => IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 => IDb.Update");
        }

        void IFileFunction.Close() 
        {
            Console.WriteLine("Class1 => Close");

        }

        void IFileFunction.Delete()//Cannot Add any access specifier over here by default they are private
        {
            Console.WriteLine("Class1 => Delete");

        }

        void IFileFunction.Open()
        {
            Console.WriteLine("Class1 => Open");

        }
    }

    public class MainClass
    {
        static void Main6()
        {
            Class1 o = new Class1();
            IFileFunction oIFile;
            oIFile = o;
            oIFile.Delete();
            Console.ReadLine();
        }
    }
}

namespace Interfaces4
{
    public interface IDbFunctions
    {
        void Insert();

        void Update();

        void Delete();
    }
    public interface IFileFunction
    {
        void Open();
        void Close();
        void Delete();
    }

    //Name And Signature is same then this problem occurs
    public class Class1 : IDbFunctions, IFileFunction
    {

         void IDbFunctions.Delete()
        {
            Console.WriteLine("Class1 => IDb.Delete");
        }
        public void Display()
        {
            Console.WriteLine("Class1 => IDb.Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 => IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 => IDb.Update");
        }

        public void Close()
        {
            Console.WriteLine("Class1 => File.Close");

        }

        void IFileFunction.Delete()//Cannot Add any access specifier over here by default they are private
        {
            Console.WriteLine("Class1 => File.Delete");

        }

        public void Open()
        {
            Console.WriteLine("Class1 => File.Open");

        }
    }

    public class MainClass
    {
        static void Main()
        {
            Class1 o = new Class1();
            IFileFunction oIFile;
            oIFile = o;
            oIFile.Delete();

            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Delete();
            Console.ReadLine();
        }
    }
}

//TO DO : One Interface Inherite From another Interface