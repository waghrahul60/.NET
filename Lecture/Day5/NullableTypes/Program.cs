﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //short? s = 0;

            int? i = 10; //Complier Converts into =>Nullable<int> i = 10; 
             i = null;

            int j = 0;
            /*if(i != null)
            {
                j = (int)i;
            }
            else
            {
                j = 0;
            }*/

            /*if (i.HasValue)
            {
                j = i.Value;
            }
            else
            {
                j = 0;
            }*/

            j = i.GetValueOrDefault();
            j = i.GetValueOrDefault(10);
            j = i ?? 10;  // null coalescing Operaator
             

            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}
