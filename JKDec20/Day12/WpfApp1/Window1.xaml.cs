﻿using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnShowFullName_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " +  txtLastName.Text;
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
           // MessageBox.Show("txtFirstName_KeyDown");
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("txtFirstName_TextChanged");
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;

        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
        }
    }
}
