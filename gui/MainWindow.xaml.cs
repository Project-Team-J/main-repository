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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        WebClient client = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void SubmitUser_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("user_name", user_name.Text);
            UserInfo.Add("user_mail", user_mail.Text);
            UserInfo.Add("user_pass", user_pass.Text);
           

            byte[] InsertUser = client.UploadValues("http://localhost/Project%20j/New%20folder/sign-up.php", "POST", UserInfo);
            client.Headers.Add("Content-Type","binary/octet-stream");
           
            Console.WriteLine(InsertUser);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 reg = new Window2();
            reg.Show();
             
        }

        private void txt_umail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
