/*CDAC has certain number of batches. each batch has certain number of students
accept number of batches from the user. for each batch accept number of students.
create an array to store mark for each student. accept the marks.
display the marks.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDACBatches
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no of batches:");
            int batch = Convert.ToInt32(Console.ReadLine());
            int[][] arr = new int[batch][];

            for (int i = 0; i < batch; i++)
            {
                Console.WriteLine("Enter the batch Size:");
                int batchSize = Convert.ToInt32(Console.ReadLine());
                arr[i] = new int[batchSize];
            }

            for(int i = 0; i< arr.Length; i++)
            {
                for(int j =0;j<arr[i].Length; j++)
                {
                    Console.WriteLine("Enter Marks of students [{0}{1}]",i,j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("=======");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("Marks of students {0} {1} is {2}", i, j, arr[i][j]);
                    
                }
                Console.WriteLine("=======");
            }
            Console.ReadLine();
        }
    }
}
