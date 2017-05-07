﻿using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for Widgets.xaml
    /// </summary>
    public partial class Widgets : Window
    {

        public Widgets()
        {
            this.Left = 350;
            this.Top = 200;
            InitializeComponent();
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Daily_Word dw = new Daily_Word();
            dw.Show();
        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            //Login log = new Login();
            //Close();
            //log.Show();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Translation ts = new Translation();
            ts.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Exchange ex = new Exchange();
            ex.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Weather we = new Weather();
            we.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Todo_list td = new Todo_list();
            td.Show();
        }
    }
}