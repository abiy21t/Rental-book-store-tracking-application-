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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//add book button
        {
            AddBooksPage bk = new AddBooksPage();
            bk.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)//add admin button
        {
            AddNewAdmin ad = new AddNewAdmin();
            ad.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)//logout button
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//add clerk/new user
        {
            CreateUser cu = new CreateUser();
            cu.Show();
            this.Close();
        }
    }
}
