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
        private OpenFileDialog FileChooser;
        WebClient client = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UploadImage_OnClick(object sender, RoutedEventArgs e)
        {
            FileChooser= new OpenFileDialog(); 
            FileChooser.Title = "Choose your Image";
            FileChooser.Filter = "Image Files(*.bmp,*.png,*.jpg,*.jpeg) | *.bmp; *.png; *.jpg; *.jpeg";
            if(FileChooser.ShowDialog().Value)
            {
                UserImage.Text = FileChooser.FileName; 
            }
        }

        private void SubmitUser_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection UserInfo = new NameValueCollection();
            UserInfo.Add("UserName",UserName.Text);
            UserInfo.Add("UserMail",UserMail.Text);
            UserInfo.Add("UserPassword",UserPassword.Password);
            UserInfo.Add("UserImage",UserImage.Text);

            byte[] InsertUser = client.UploadValues("http://127.0.0.1/pro/InsertUser.php", "POST", UserInfo);
            client.Headers.Add("Content-Type","binary/octet-stream");
            byte[] InsertImage = client.UploadFile("http://127.0.0.1/pro/InsertUser.php", FileChooser.FileName);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window2 reg = new Window2();
            reg.Show();
             
        }
    }
}
