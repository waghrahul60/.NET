using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ReflectioExample
{
    class Program
    {
        static void Main()
        {
            //D:\Trainings\JKDec20\Day2\ClassBasics\bin\Debug
            Assembly asm = Assembly.LoadFrom(@"D:\Trainings\JKDec20\Day2\ClassBasics\bin\Debug\ClassBasics.Exe");


            //Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes();
            foreach ( Type t in arrTypes)
            {
                Console.WriteLine("    " + t.Name);
                MethodInfo[] arrMethods = t.GetMethods();
                foreach (MethodInfo m in arrMethods)
                {
                    Console.WriteLine("        " +m.Name);
                }
            }

            Console.ReadLine();
        }
    }
}
