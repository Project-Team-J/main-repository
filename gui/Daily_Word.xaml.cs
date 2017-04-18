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
using System.Collections.Specialized;
using System.Speech.Synthesis;

namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for Daily_Word.xaml
    /// </summary>
    public partial class Daily_Word : Window
    {
        public Daily_Word()
        {
            InitializeComponent();

            using (WebClient client = new WebClient())
            {
                NameValueCollection dailyWordCol = new NameValueCollection();
                dailyWordCol.Add("daily_word", "");
                dailyWordCol.Add("word", "");
                byte[] response = client.UploadValues("http://localhost/", "POST", dailyWordCol);
                var responseString = Encoding.Default.GetString(response);
                responseString = responseString.Replace("\r", "").Replace("\n", "");
                this.Label_word.Content = responseString;
                dailyWordCol = new NameValueCollection();
                dailyWordCol.Add("daily_word", "");
                dailyWordCol.Add("image", "");
                response = client.UploadValues("http://localhost/", "POST", dailyWordCol);
                responseString = Encoding.Default.GetString(response);
                responseString = responseString.Replace("\r", "").Replace("\n", "");
                var fullFilePath = @responseString;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                this.Images.Source = bitmap;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.Speak((string)this.Label_word.Content);
        }
    }
}
