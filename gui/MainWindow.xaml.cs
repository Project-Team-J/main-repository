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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MusicP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            musicbrowser.Navigate("https://www.internet-radio.com/player/?mount=http://pulseedm.cdnstream1.com:8124/1373_128.m3u&title=PulseEDM%20Dance%20Music%20Radio&website=www.pulseedm.com");
        }

        private void RockB_Click(object sender, RoutedEventArgs e)
        {
            musicbrowser.Navigate("https://www.internet-radio.com/player/?mount=http://uk5.internet-radio.com:8251/listen.pls&title=Classic%20Rock%20HD%20Plus&website=http://classicrockflorida.com");
    
        }


        private void HipHopB_Click_1(object sender, RoutedEventArgs e)
        {
            musicbrowser.Navigate("https://www.internet-radio.com/player/?mount=http://us1.internet-radio.com:8336/listen.pls&title=LadyLinQRadio&website=http://www.internet-radio.com");

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
            this.Close();
        }
    }
}
