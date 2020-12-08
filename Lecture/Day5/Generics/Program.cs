using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class MyOperations<T>
    {
        public static void Swap(ref T i, ref T j)
        {
            T temp;
            temp = i;
            i = j;
            j = temp;
        }
    }
    class IntOperations
    {
        public static void Swap(ref int i, ref int j)
        {
            int temp;
            temp = i;
            i = j;
            j = temp;
        }
    }
    class shortOperations
    {
        public static void Swap(ref short i, ref short j)
        {
            short temp;
            temp = i;
            i = j;
            j = temp;
        }
    }
}
