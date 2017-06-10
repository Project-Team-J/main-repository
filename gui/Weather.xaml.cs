using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Weather : Window
    {
        public Weather()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {

                NameValueCollection weatherCol = new NameValueCollection();
                weatherCol.Add("weather", "");
                weatherCol.Add("city", "ashkelon");
                byte[] response = client.UploadValues(Login.server, "POST", weatherCol);
                String responseString = Encoding.UTF8.GetString(response);
                dynamic stuff = JsonConvert.DeserializeObject(responseString);
                date1.Text = stuff.date[0];
                date2.Text = stuff.date[1];
                date3.Text = stuff.date[2];
                date4.Text = stuff.date[3];
                prop1.Text = "Highest: " + stuff.tmph[0] + "c\r\n" + "Lowest:  " + stuff.tmpl[0] + "c\r\n" + "AvgHumidity: " + stuff.humid[0];
                prop2.Text = "Highest: " + stuff.tmph[1] + "c\r\n" + "Lowest:  " + stuff.tmpl[1] + "c\r\n" + "AvgHumidity: " + stuff.humid[1];
                prop3.Text = "Highest: " + stuff.tmph[2] + "c\r\n" + "Lowest:  " + stuff.tmpl[2] + "c\r\n" + "AvgHumidity: " + stuff.humid[2];
                prop4.Text = "Highest: " + stuff.tmph[3] + "c\r\n" + "Lowest:  " + stuff.tmpl[3] + "c\r\n" + "AvgHumidity: " + stuff.humid[3];

                String fullFilePath1 = @stuff.imgs[0];
                BitmapImage bitmap1 = new BitmapImage();
                bitmap1.BeginInit();
                bitmap1.UriSource = new Uri(fullFilePath1, UriKind.Absolute);
                bitmap1.EndInit();
                this.Img1.Source = bitmap1;
                String fullFilePath2 = @stuff.imgs[0];
                BitmapImage bitmap2 = new BitmapImage();
                bitmap2.BeginInit();
                bitmap2.UriSource = new Uri(fullFilePath2, UriKind.Absolute);
                bitmap2.EndInit();
                this.Img2.Source = bitmap2;
                String fullFilePath3 = @stuff.imgs[1];
                BitmapImage bitmap3 = new BitmapImage();
                bitmap3.BeginInit();
                bitmap3.UriSource = new Uri(fullFilePath3, UriKind.Absolute);
                bitmap3.EndInit();
                this.Img3.Source = bitmap3;
                String fullFilePath4 = @stuff.imgs[0];
                BitmapImage bitmap4 = new BitmapImage();
                bitmap4.BeginInit();
                bitmap4.UriSource = new Uri(fullFilePath4, UriKind.Absolute);
                bitmap4.EndInit();
                this.Img4.Source = bitmap4;


            }
        }
    }

}
