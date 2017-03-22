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
    /// Interaction logic for LoginnPage.xaml
    /// </summary>
    public partial class LoginnPage : Window
    {
        public LoginnPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            LoginPclass log = new LoginPclass();
            if (radAdmin.IsChecked == true)
            {
                log.UserName = txtuname.Text;
                log.Password = passwordBox.Password;
                bool auth = log.AdminLogin(log.UserName, log.Password);
                if (auth == true)
                {
                    AdminHome adh = new AdminHome();
                    adh.Show();
                    this.Hide();
                    //MessageBox.Show("user name and password correct");
                }
                else
                {
                    MessageBox.Show("user name and password incorrect");
                }
            }
            if (radClerk.IsChecked == true)
            {
                log.UserName = txtuname.Text;
                log.Password = passwordBox.Password;
            }
        }
    }
}