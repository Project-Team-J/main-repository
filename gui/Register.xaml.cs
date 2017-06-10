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
using Newtonsoft.Json;

namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register : Window
    {

        WebClient client = new WebClient();
        public Register()
        {
            this.Left = 450;
            this.Top = 200;
            InitializeComponent();
        }


        private void SubmitUser_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("register", "");
            UserInfo.Add("user_name", user_name.Text);
            UserInfo.Add("user_mail", user_mail.Text);
            UserInfo.Add("user_pass", user_pass.Password);
            var InsertUser = client.UploadValues(Login.server, "POST", UserInfo);
            var responseString = Encoding.UTF8.GetString(InsertUser);
            dynamic stuff = JsonConvert.DeserializeObject(responseString);
            String cases = stuff.msg;
            switch (cases)
            {
                case "register successfully!":
                    {
                        Login log = new Login();
                        log.UserMail.Text = user_mail.Text;
                        log.UserPassword.Password = user_pass.Password;
                        log.Label_message.Content = "Your account has been created successfully please login!";
                        Close();
                        log.Show();
                        break;
                    }
                case "invalid username!":
                    {
                        Label_message.Content = "Invalid username! you can use letters, numbers and periods!";
                        break;
                    }
                case "invalid email!":
                    {
                        Label_message.Content = "Invalid email!\nYou can use letters, numbers and periods\nFormat example example@example.com!";
                        break;
                    }
                case "invalid username!invalid email!":
                    {
                        Label_message.Content = "Invalid username and email,\nYou can use letters, numbers and periods!";
                        break;
                    }
                case "Sorry username already taken!":
                    {
                        Label_message.Content = "Sorry username already taken!";
                        break;
                    }
                case "Sorry email id already taken!":
                    {
                        Label_message.Content = "Sorry email id already taken!";
                        break;
                    }

                default:
                    {
                        Label_message.Content = "Server error!";
                        break;
                    }
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            Close();
            log.Show();

        }

        private void txt_umail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}