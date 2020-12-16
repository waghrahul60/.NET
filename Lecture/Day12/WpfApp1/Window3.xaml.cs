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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstNames.Items.Add("Viraat");
            lstNames.Items.Add("Rohit");
            lstNames.Items.Add("Pujaara");
            lstNames.Items.Add("Rahane");

        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
           /* MessageBox.Show(lstNames.Items.Count.ToString());
            MessageBox.Show(lstNames.SelectedItem.ToString());
            MessageBox.Show(lstNames.SelectedIndex.ToString());*/

            foreach (var item in lstNames.SelectedItems)
            {
                MessageBox.Show(item.ToString());

            }
            
        }

        private void btnListRemove_Click(object sender, RoutedEventArgs e)
        {
            lstNames.Items.RemoveAt(lstNames.SelectedIndex);
        }
    }
}
