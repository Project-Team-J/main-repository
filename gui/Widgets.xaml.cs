using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                //dw.Image.? = responseString;
            }
            dw.Show();

        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            Close();
            log.Show();
        }
    }
}
