using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsExample
{
    class Program
    {
        static void Main()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(10);
            objArrayList.Add("aaa");
            objArrayList.Add(10.5);
            objArrayList.Add(true);

            Console.WriteLine(objArrayList.Count);
            objArrayList.Remove("aaa");
            objArrayList.RemoveAt(0);

            foreach (object  o in objArrayList)
            {
                Console.WriteLine(o);
            }
            //objArrayList.AddRange(obj2)

            //objArrayList.Capacity = 100;
            //objArrayList.TrimToSize()

            //objArrayList.Clear
            // bool isThere = objArrayList.Contains(10);
            //objArrayList.CopyTo(arr)
            //objArrayList.Insert(0, "aa");
            // objArrayList.InsertRange
            //objArrayList.RemoveRange
            //object[] arr = objArrayList.ToArray();
            //objArrayList.BinarySearch
            //objArrayList.IndexOf
            //objArrayList.LastIndexOf

            Console.ReadLine();
        }
    }
}
