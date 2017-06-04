using Newtonsoft.Json;
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
    /// Interaction logic for Photo_Album.xaml
    /// </summary>
    public partial class Photo_Album : Window
    {
        int index = 0;
        dynamic stuff=null;


        public Photo_Album()
        {
            InitializeComponent();
            combo.Items.Add("sea");
            combo.Items.Add("car");
            combo.Items.Add("abstract");
            combo.Items.Add("sky");
            combo.Items.Add("computer");
        }

    

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (combo.Text != null)
            {
                using (WebClient client = new WebClient())
                {
                    NameValueCollection photo_album = new NameValueCollection();
                    photo_album.Add("pa", "");
                    photo_album.Add("word", combo.Text);
                    byte[] response = client.UploadValues("http://localhost/", "POST", photo_album);
                    String responseString = Encoding.UTF8.GetString(response);
                    stuff = JsonConvert.DeserializeObject(responseString);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string tmp = stuff["image" + index.ToString()];
                    bitmap.UriSource = new Uri(tmp, UriKind.Absolute);
                    bitmap.EndInit();
                    this.pic.Source = bitmap;
                }
            }
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                index++;
                if (index == 30)
                    index = 0;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                string tmp = stuff["image" + index.ToString()];
                bitmap.UriSource = new Uri(tmp, UriKind.Absolute);
                bitmap.EndInit();
                this.pic.Source = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                --index;
                if (index == -1)
                    index = 29;          
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                string tmp = stuff["image" + index.ToString()];
                bitmap.UriSource = new Uri(tmp, UriKind.Absolute);
                bitmap.EndInit();
                this.pic.Source = bitmap;
        }

     
    }
}
