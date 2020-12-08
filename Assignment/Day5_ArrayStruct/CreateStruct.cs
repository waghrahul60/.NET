using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Student[] s = new Student[5];

            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("name of student =");
                string name = Console.ReadLine();
                Console.WriteLine("Rollno of Student =");
                int rollNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Marks of Student =");
                decimal Marks = Convert.ToDecimal(Console.ReadLine());
                s[i] = new Student(name, rollNo, Marks);
            }


            Console.ReadLine();

            for (i = 0; i < 5; i++)
            {
                s[i].Display();
            }
            Console.ReadLine();

        }
    }
    public struct Student
    {
        private string name;
        private int rollNo;
        private decimal marks;

        public Student(string name, int rollNo, decimal marks)
        {
            this.name = "No name";
            this.rollNo = 1;
            this.marks = 32;
            this.Name = name;
            this.RollNo = rollNo;
            this.Marks = marks;

        }

        public string Name
        {
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("invalid name");
                }
            }
            get
            {
                return name;
            }
        }

        public int RollNo
        {
            set
            {
                if (value > 0)
                {
                    rollNo = value;
                }
                else
                {
                    Console.WriteLine("wrong rollno");
                }
            }
            get
            {
                return rollNo;
            }
        }

        public decimal Marks
        {
            set
            {
                if (value > 0)
                {
                    marks = value;
                }
                else
                {
                    Console.WriteLine("invalid marks");
                }
            }
            get
            {
                return marks;
            }
        }


        public void Display()
        {
            Console.WriteLine(Name + " " + RollNo + " " + Marks);
        }
    }
}
