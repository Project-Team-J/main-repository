using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        WebClient client = new WebClient();
        public Login()
        {
            this.Left = 450;
            this.Top = 200;
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            Close();
            reg.Show();

        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("login", UserMail.Text);
            UserInfo.Add("UserMail", UserMail.Text);
            UserInfo.Add("UserPassword", UserPassword.Password);
            byte[] InsertUser = client.UploadValues("http://localhost/", "POST", UserInfo);
            client.Headers.Add("Content-Type", "binary/octet-stream");
            Widgets wid = new Widgets();
            Close();
            wid.Show();
        }
    }
   
}
