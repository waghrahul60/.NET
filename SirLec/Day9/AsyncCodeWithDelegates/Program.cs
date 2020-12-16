using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//calling a method asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates1
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Action o = Display;
            o.BeginInvoke(null, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates2
{
    class Program
    {
        static void Main2()
        {
            Console.WriteLine("Before");
            Action<string> o = Display;
            o.BeginInvoke("aaa", null, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func
namespace AsyncCodeWithDelegates3
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            o.BeginInvoke("aaa", CallBackFunc, null) ;
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }
        
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func ( as an anon method - to enable us to access objDel in the callback func) 
//get the return value with objDel.EndInvoke
namespace AsyncCodeWithDelegates4
{
    class Program
    {
         static void Main()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            o.BeginInvoke("aaa", delegate(IAsyncResult ar)
            {
                Console.WriteLine("callback func called");
                string retval = o.EndInvoke(ar);
                Console.WriteLine("retval = " + retval);
            }, null);
            
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
           
        }
    }
}


