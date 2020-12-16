using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        int a = 0;
        int b = 0;
        int c = 0;
        private void txtNum1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                b = 0;
                a = Convert.ToInt32(txtNum1.Text);
                b = Convert.ToInt32(txtNum2.Text);
                c = a + b;
                txtsum.Text = Convert.ToString(c);
            }
            catch(Exception ex)
            {
    
            }
        }

        private void txtNum2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                a = 0;
                a = Convert.ToInt32(txtNum1.Text);
                b = Convert.ToInt32(txtNum2.Text);
                c = a + b;
                txtsum.Text = Convert.ToString(c);
            }
            catch (Exception ex)
            {

            }
        }

        /*private void txtNum1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyInterop.VirtualKeyFromKey(e.Key).ToString();
            MessageBox.Show(e.Key.ToString());
            MessageBox.Show(KeyInterop.VirtualKeyFromKey(e.Key).ToString());

            e.Handled = true;

        }*/

        private void txtNum1_KeyDown_1(object sender, KeyEventArgs e)
        {
            int a = Convert.ToInt32(KeyInterop.VirtualKeyFromKey(e.Key).ToString());
            //MessageBox.Show(e.Key.ToString());
            //MessageBox.Show(KeyInterop.VirtualKeyFromKey(e.Key).ToString());
            if(a >= 48 && a <= 57 || a >= 96 && a <= 105)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Invalid!!! Plz enter Numbers Only");
            }


        }

        private void txtNum2_KeyDown(object sender, KeyEventArgs e)
        {

            int a = Convert.ToInt32(KeyInterop.VirtualKeyFromKey(e.Key).ToString());
        
            if (a >= 48 && a <= 57 || a >= 96 && a <= 105)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Invalid!!! Plz enter Numbers Only");
            }

        }
    }
}
