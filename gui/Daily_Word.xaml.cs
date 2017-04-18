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
using Newtonsoft.Json;

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
                byte[] response = client.UploadValues("http://localhost/", "POST", dailyWordCol);
                String responseString = Encoding.UTF8.GetString(response);
                dynamic stuff = JsonConvert.DeserializeObject(responseString);
                this.Label_word.Content = (string)stuff.word;
                String fullFilePath = @stuff.img;
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
