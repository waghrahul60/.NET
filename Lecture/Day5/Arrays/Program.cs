using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al1 = new ArrayList();
            al1.Add("Rahul");
            al1.Add("mohit");
            al1.Add("Kalpesh");
            al1.Add("Kunal");

            ArrayList al2 = new ArrayList();
            al2.Add("Batman");
            al2.Add("Superman");
            al2.Add("Spiderman");
            al2.Add("Shaktimaan");

            ArrayList b = new ArrayList();
            b.Add(1);
            b.Add(2);
            b.Add(3);


            //al1.AddRange(al2);
            //al1.CopyTo(b);
            //al1.Clear();
           
            int a = al1.Count;
            al1.Capacity = 10;

            al1.Insert(0, "omkar");
            al1.InsertRange(0, al2);

            al1.RemoveRange(0, 4);
            //al1.BinarySearch(al2);

            foreach (string o in al1)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("=======================================");

            object[] arr = al1.ToArray();

            Console.WriteLine(a);
            foreach (string o in arr)
            {
                Console.WriteLine(o);
            }
            Console.ReadLine();


        }
    }
}
