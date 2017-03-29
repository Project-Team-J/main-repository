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

namespace LogIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog FileChooser;
        WebClient client = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BackToRegister(object sender, RoutedEventArgs e)
        {
            MainWindow reg = new MainWindow();
            reg.Show();

        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("UserMail", UserMail.Text);
            UserInfo.Add("UserPassword", UserPassword.Password);
            byte[] InsertUser = client.UploadValues("http://127.0.0.1/pro/LoginUser.php", "POST", UserInfo);
            client.Headers.Add("Content-Type", "binary/octet-stream");

        }
    }
   
}
