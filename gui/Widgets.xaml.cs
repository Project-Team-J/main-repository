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

        public Widgets()
        {
            this.Left = 350;
            this.Top = 200;
            InitializeComponent();
        }

 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Daily_Word dw = new Daily_Word();
            using (WebClient client = new WebClient())
            {
                NameValueCollection UserInfo = new NameValueCollection();
                UserInfo.Add("daily_word", "");
                UserInfo.Add("word", "");
                byte[] response = client.UploadValues("http://localhost/", "POST", UserInfo);
                var responseString = Encoding.Default.GetString(response);
                responseString = responseString.Replace("\r", "").Replace("\n", "");
                dw.Label_word.Content = responseString;
                UserInfo = new NameValueCollection();
                UserInfo.Add("daily_word", "");
                UserInfo.Add("image", "");
                response = client.UploadValues("http://localhost/", "POST", UserInfo);
                responseString = Encoding.Default.GetString(response);
                responseString = responseString.Replace("\r", "").Replace("\n", "");
                var fullFilePath = @responseString;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                dw.Images.Source = bitmap;


            }
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
    }
}
