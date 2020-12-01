using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBasic
{
    class constructor
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1();
            //o.i = 100;
            //Console.WriteLine(o.i);

            //o.SetI(101);
            //Console.WriteLine(o.GetI());

            o.P1 = 10;
            Console.WriteLine(o.P1);

            //o.p1 = ++o.p1 + o.p1++ - o.p1-- - --o.p1;

            //for p2
            o.P2 = "rahul";
            Console.WriteLine(o.P2);

            // for p3
            //o.P3 = 10; Read only Property
            Console.WriteLine(o.P3);

            //for p4  | Write only Property
            o.P4 = "Write only";

            //for p5  | Write only Property
            Console.WriteLine(o.P5);

            o = null;
            Console.ReadLine();
            GC.Collect();

            Console.ReadLine();
        }
    }
    public class Class1
    {
        #region constructor
        public Class1()
        {
            Console.WriteLine("no para cons called");
        }

        public Class1(int P1)
        {
            Console.WriteLine("int param cons called");
            this.P1 = P1;
        }
        #endregion


        // Never ever Write anything in destructor
        ~Class1()
        {
            Console.WriteLine("DESC");
        }

        #region properties
        //public int i;
        private int i;
        public void SetI(int x)
        {
            if (x < 100)
            {
                i = x;
            }
            else
            {
                //throw an exception here
                Console.WriteLine("invilid value");
            }
        }

        public int GetI()
        {
            return i;
        }

        //property
        private int p1;
        public int P1
        {
            set //get call  when o.p1 = 10
            {
                //passed valu is avaaliable as 'value'
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    Console.WriteLine("invilid value");
                }

            }
            get //get caall when Console.WriteLine(o.P1) trying to read value
            {
                return p1;
            }
        }

        private string p2;
        public string P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        //public string P2;

        private string p3;
        public string P3
        {
            get { return p3; }
        }

        private string p4;
        public string P4
        {
            set { p4 = value; }
        }

        //auto property
        public int P5 { get; set; }


    }
    #endregion
}
