using System;
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
        private static String uname;
        private static String upass;

        public Widgets()
        {
            this.Left = 350;
            this.Top = 200;
            InitializeComponent();
        }


        public static String getUname()
        {
            return uname;
        }

        public static String getUpass()
        {
            return upass;
        }

        public static void setUname(String u)
        {
            uname = u;
        }

        public static void setUpass(String p)
        {
            upass = p;
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MusicP mp = new MusicP();
            mp.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Photo_Album pa = new Photo_Album();
            pa.Show();
        }


    }
}