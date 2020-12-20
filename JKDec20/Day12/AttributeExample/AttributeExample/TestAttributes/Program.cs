using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAttributes
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(Class1);
            object[] objArr = t.GetCustomAttributes(false);
            foreach (Attribute a in objArr)
            {
                Console.WriteLine(a.GetType().Name);
            }
            Console.ReadLine();
        }
    }
    //[XAttribute]
    [X]
    [Serializable]
    [MyAttributes.Attribute1("aaa")]
    class Class1
    {
        
    }

    public class XAttribute : System.Attribute
    {
        public string Name { get; set; }
        public XAttribute(string Name="")
        {
            this.Name = Name;
        }
    }
}
