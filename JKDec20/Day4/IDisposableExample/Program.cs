﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableExample
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();

            o.Display();

            o.Dispose();

            o.Display();

            Console.ReadLine();
        }
        static void Main()
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
            CheckForDisposed();
            Console.WriteLine("Display");
        }
        private void CheckForDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Class1");
        }
        private bool isDisposed=false;
        public void Dispose()
        {
            Console.WriteLine("dispose called. free resources here");
            isDisposed = true;
        }
    }
}
