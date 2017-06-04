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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MusicP : Window
    {
        NameValueCollection music = new NameValueCollection();
        WebClient client = new WebClient();
        byte[] response;
        String responseString;
        public MusicP()
        {
            InitializeComponent();
            music.Add("music", "");
            musicbrowser.Navigate("http://www.100fm.co.il/jwplayer/jwplayer.aspx");
            YourMusic.Text = "Or input your favourite song's YouTube URL here!";
        }

        private void musicbrowser_navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            txtUrl.Text = e.Uri.OriginalString;
        }

        private void txtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtUrl.Text = "Welcome to 'Team J's Media Player',Enjoy your music!";
        }

        private void HouseB_Click_1(object sender, RoutedEventArgs e)
        {

            music.Add("house", "");
            response = client.UploadValues("http://localhost/", "POST", music);
            responseString = Encoding.UTF8.GetString(response);
            musicbrowser.Navigate(responseString);
        }

        private void RockB_Click(object sender, RoutedEventArgs e)
        {
            music.Add("rock", "");
            response = client.UploadValues("http://localhost/", "POST", music);
            responseString = Encoding.UTF8.GetString(response);
            musicbrowser.Navigate(responseString);

        }


        private void HipHopB_Click_1(object sender, RoutedEventArgs e)
        {
            music.Add("hip", "");
            response = client.UploadValues("http://localhost/", "POST", music);
            responseString = Encoding.UTF8.GetString(response);
            musicbrowser.Navigate(responseString);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void YTButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                musicbrowser.Navigate(YourMusic.Text);
                YourMusic.Text = "Enter Another YouTube Song!";
            }
            catch (Exception Ex)
            {
                YourMusic.Text = "Please enter a valid YouTube URL";
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            musicbrowser.Navigate("http://www.blank.org");
            this.Close();
        }
    }
}
