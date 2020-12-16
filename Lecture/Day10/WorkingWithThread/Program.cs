using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace WorkingWithThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(Func2);

            t1.Priority = ThreadPriority.Highest;
            /* t1.IsBackground = true;
            t2.IsBackground = true;*/
            
            t1.Start();
            t2.Start();

            //t1.Abort();
            //t1.IsAlive
           


            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main :" + i);
            }

            Console.ReadLine();
        }
        static void Func1()
        {
            for(int i=0;i< 1000; i++)
            {
                Console.WriteLine("First :" +i);
            }
        }

        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Second :" + i);
            }
        }
    }
}
