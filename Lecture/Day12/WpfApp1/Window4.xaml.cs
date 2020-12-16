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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstNames1.Items.Add("Viraat");
            lstNames1.Items.Add("Rohit");
            lstNames1.Items.Add("Pujaara");
            lstNames1.Items.Add("Rahane");
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
                foreach (var item in lstNames1.SelectedItems)
                {
                    lstNames2.Items.Add(item);
                }
                int a = lstNames1.SelectedItems.Count;

                for (int i = a; i > 0; i--)
                {
                    lstNames1.Items.Remove(lstNames1.SelectedItems[0]);
                }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lstNames2.SelectedItems)
            {
                lstNames1.Items.Add(item);
            }
            int a = lstNames2.SelectedItems.Count;

            for (int i = a; i > 0; i--)
            {
                lstNames2.Items.Remove(lstNames2.SelectedItems[0]);
            }
        }

        private void lstNames1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAllRight_Click(object sender, RoutedEventArgs e)
        {
                lstNames1.SelectAll();
           
                foreach (var item in lstNames1.SelectedItems)
                {
                    lstNames2.Items.Add(item);
                    
                }

                int a = lstNames1.SelectedItems.Count;

                for (int i = a; i > 0; i--)
                {
                    lstNames1.Items.Remove(lstNames1.SelectedItems[0]);
                }
        }

        private void btnAllLeft_Click(object sender, RoutedEventArgs e)
        {
            lstNames2.SelectAll();

            foreach (var item in lstNames2.SelectedItems)
            {
                lstNames1.Items.Add(item);

            }

            int a = lstNames2.SelectedItems.Count;

            for (int i = a; i > 0; i--)
            {
                lstNames2.Items.Remove(lstNames2.SelectedItems[0]);
            }
        }
    }
}
