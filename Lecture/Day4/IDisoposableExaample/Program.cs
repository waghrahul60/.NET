using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisoposableExaample
{
    class Program
    {
        static void Main1(string[] args)
        {
            Class1 o = new Class1();
            o.Display();
            o.Dispose();
            o.Display();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            using (Class1 o = new Class1())
            {
                o.Display();
            }
      
            Console.ReadLine();
        }
    }
    public class Class1 : IDisposable
    {
        public void Display()
        {
            CheckForDisplay();
            Console.WriteLine("Display");
        }
        private void CheckForDisplay()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Class1"); //exception 
            }
           
        }
        private bool isDisposed = false; //Initial value is false

        public void Dispose()
        {
            Console.WriteLine("Free Resorces");
            isDisposed = true;
        }
    }
}
