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

namespace Final
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//cancel button
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//create button
        {

        }
    }
}
