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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private OpenFileDialog FileChooser;
        WebClient client = new WebClient();
        public Window2()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("UserMail", UserMail.Text);
            UserInfo.Add("UserPassword", UserPassword.Password);
            byte[] InsertUser = client.UploadValues("http://127.0.0.1/pro/LoginUser.php", "POST", UserInfo);
            client.Headers.Add("Content-Type", "binary/octet-stream");

            switch (client.ToString())
            {
                case "Account non register":
                    {
                        MessageBox.Show("Account non register!!");
                        break;
                    }
                case "Wrong Password":
                    {
                        MessageBox.Show("Wrong Password!!!");
                        break;
                    }
                case "Login succsefully":
                    {
                        MessageBox.Show("Login succsefully!!!");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("bad comunication!!");
                        break;
                    }



            }

        }

        private void btn_rgst_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow f1 = new MainWindow();
            f1.Show();
            
        }
    }
}
