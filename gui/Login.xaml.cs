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
        WebException x;
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
                UserInfo.Add("login", "");
                UserInfo.Add("username", UserMail.Text);
                UserInfo.Add("password", UserPassword.Password);
                byte[] login = client.UploadValues("http://localhost/", "POST", UserInfo);
                var responseString = Encoding.Default.GetString(login);
                responseString = responseString.Replace("\r", "").Replace("\n", "");
                Label_message.Content = responseString;
                switch (responseString)
                {
                    case "login successfully!":
                        {
                            Widgets wid = new Widgets();
                            Close();
                            wid.Show();
                            break;
                        }
                    case "Wrong Details!":
                        {
                            Label_message.Content = "Wrong Details!";
                            break;
                        }
                    case "invalid username!":
                        {
                            Label_message.Content = "Invalid username! you can use letters, numbers and periods!";
                            break;
                        }
                    default:
                        {
                            Label_message.Content = "Server error!";
                            break;
                        }
                }
        }
    }
   
}
