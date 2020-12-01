using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClassConcepts
{
    class PrimeNumbers
    {
        public static void Main(string[] args)
        {
            int n; 
            int i, m= 0, flag = 0;
            Console.Write("Enter a a number to check a prime number :");
            n = int.Parse(Console.ReadLine());
            m = n / 2;
            for(i=2; i<=m; i++)
            {
                if(n % i == 0)
                {
                    Console.Write("Enter no is Not prime no .");
                    flag = 1;
                    break;
                    
                }
            }
            if (flag == 0)
                Console.Write("Number is a prime nouber");

            Console.ReadLine();
        }
    }
}
