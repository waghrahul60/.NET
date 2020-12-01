using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClassConcepts
{
    class Demo
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("sizeof(int): {0}", sizeof(int));//4
            Console.WriteLine("sizeof(float): {0}", sizeof(float));//4
            Console.WriteLine("sizeof(char): {0}", sizeof(char));//2
            Console.WriteLine("sizeof(double): {0}", sizeof(double));//8
            Console.WriteLine("sizeof(bool): {0}", sizeof(bool));//1-bit

            Console.WriteLine("sizeof(byte)     : {0}", sizeof(byte));
            Console.WriteLine("sizeof(sbyte)    : {0}", sizeof(sbyte));
            Console.WriteLine("sizeof(short)    : {0}", sizeof(short));
            Console.WriteLine("sizeof(ushort)   : {0}", sizeof(ushort));
            Console.WriteLine("sizeof(char)     : {0}", sizeof(char));
            Console.WriteLine("sizeof(int)      : {0}", sizeof(int));
            Console.WriteLine("sizeof(float)    : {0}", sizeof(float));
            Console.WriteLine("sizeof(double)   : {0}", sizeof(double));
            Console.WriteLine("sizeof(bool)     : " + sizeof(bool));

            

            int a = 10;
            int b = 3;

            int sum = a + b;
            int sub = a - b;
            int mul = a + b;
            float div = (float)(a/b);
            Console.WriteLine("Addition of {0} and {1} is = {2}",a,b,sum);
            Console.WriteLine($"Addition of {a} and {b} is = {sum}");
            */
            int a;
            int b;
            int min;
            int max;

            //input numbers
            Console.Write("Enter first number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());


            //finding max number using if-else
            if (a > b)
                max = a;
            else
                max = b;

            //finding min number using if else
            if (a < b)
                min = a;
            else
                min = b;

            //printing
            Console.WriteLine("Using if-else...");
            Console.WriteLine("Minimum number = {0}", min);
            Console.WriteLine("Maximum number = {0}", max);

            //finding max number using ternary operator
            max = (a > b) ? a : b;

            //finding min number using ternary operator
            min = (a < b) ? a : b;

            //printing
            Console.WriteLine("Using Ternary operator...");
            Console.WriteLine("Minimum number = {0}", min);
            Console.WriteLine("Maximum number = {0}", max);

            //hit ENTER to exit the program
            Console.ReadLine();


            Console.ReadLine();
        }
    }
}
