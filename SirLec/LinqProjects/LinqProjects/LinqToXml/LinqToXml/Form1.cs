using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqToXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XDocument d = new XDocument( new XElement( "Employees", new XElement("Employee", new XAttribute("EmpNo",1), new XElement("Name", "Vik")), 



            XDocument xDocument =
            new XDocument(
                new XElement("Employees",
                    new XElement("Employee",
                        new XAttribute("EmpNo", "1"),
                        new XElement("Name", "Suraj"),
                        new XElement("Basic", "90000"),
                        new XElement("DeptNo", "1")
                                 ),
                    new XElement("Employee",
                        new XAttribute("EmpNo", "2"),
                        new XElement("Name", "Sagar"),
                        new XElement("Basic", "52000"),
                        new XElement("DeptNo", "2")
                                 ),
                    new XElement("Employee",
                        new XAttribute("EmpNo", "3"),
                        new XElement("Name", "Rupali"),
                        new XElement("Basic", "50000"),
                        new XElement("DeptNo", "10")
                                 )
                              )
                           );
            xDocument.Save("Emps.xml");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            XDocument xDocument = XDocument.Load("Emps.xml");
            //IEnumerable<XElement> elements = xDocument.Element("Employees").Elements("Employee");
            var elements = xDocument.Element("Employees").Elements("Employee");
            foreach (var item in elements)
            {
                listBox1.Items.Add("ElementName :" + item.Name + ", Value : " + item.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument xDocument = XDocument.Load("Emps.xml");
            var element = xDocument.Element("Employees");
            element.Add(new XElement("Employee",
                        new XAttribute("EmpNo", "3"),
                        new XElement("Name", "Shruti"),
                        new XElement("Basic", "11000"),
                        new XElement("DeptNo", "10")
                                 ));
            element.AddFirst(new XElement("Employee",
                        new XAttribute("EmpNo", "4"),
                        new XElement("Name", "Mrunmayee"),
                        new XElement("Basic", "31000"),
                        new XElement("DeptNo", "5")
                                 ));
            xDocument.Save("Emps2.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
          listBox1.Items.Clear();
            XDocument xDocument = XDocument.Load("Emps2.xml");
            //IEnumerable<XElement> elements = xDocument.Descendants("Employee");//.Where(emp => ((string)emp.Element("Name")).StartsWith("V"));
            IEnumerable<XElement> elements = xDocument.Descendants("Employee").Where(emp => ((int)emp.Element("DeptNo")) > 10);
            foreach (XElement itm in elements)
            {
                listBox1.Items.Add("ElementName :" + itm.Name + ", Value : " + itm.Value);
                foreach (XAttribute item in itm.Attributes())
                    listBox1.Items.Add("ElementName :" + item.Name + ", Value : " + item.Value);

                foreach (XElement item in itm.Descendants())
                    listBox1.Items.Add("ElementName :" + item.Name + ", Value : " + item.Value);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XDocument xDocument = XDocument.Load("Emps.xml");
            IEnumerable<XElement> elements = from emp in xDocument.Descendants("Employee")
                                             where ((string)emp.Element("Name")).StartsWith("S")
                                             select emp;

            foreach (XElement itm in elements)
            {
                listBox1.Items.Add("ElementName :" + itm.Name + ", Value : " + itm.Value);
                foreach (XAttribute item in itm.Attributes())
                    listBox1.Items.Add("ElementName :" + item.Name + ", Value : " + item.Value);

                foreach (XElement item in itm.Descendants())
                    listBox1.Items.Add("ElementName :" + item.Name + ", Value : " + item.Value);

            }

        }
    }
}
