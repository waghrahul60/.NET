using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main()
        {
			Class1 obj = new Class1(20, 100);
			obj[100] = 100;
			obj[101] = 200;
			obj[102] = 300;
			obj[103] = 400;
			obj[104] = 500;

            Console.WriteLine(obj[100]);
			Console.ReadLine();
		}
    }

	public class Class1
	{
		int[] arr;
		int startPos;
        public Class1(int size, int startPos)
        {
			arr = new int[size];
			this.startPos = startPos;
        }
		//Indexer
		public int this[int index]
		{
			set
			{
				arr[index - startPos] = value;
			}
			get
			{
				return arr[index-startPos];
			}
		}
	}
}
