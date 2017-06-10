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
    /// Interaction logic for Translation.xaml
    /// </summary>
    public partial class Translation : Window
    {

        private String dict = "en-he";
        public Translation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection translationCol = new NameValueCollection();
                translationCol.Add("translation", "");
                translationCol.Add("lang", dict);
                if (trans2.Text == "")
                    trans.Text = "Please enter a text to translate --->";
                else
                {
                    translationCol.Add("text", trans2.Text);
                    byte[] response = client.UploadValues(Login.server, "POST", translationCol);
                    String responseString = Encoding.UTF8.GetString(response);
                    responseString = responseString.Replace("[", "").Replace("]", "");
                    dynamic stuff = JsonConvert.DeserializeObject(responseString);
                    trans.Text = stuff.text;
                }
                
               
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.dict = "he-en";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.dict = "en-he";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
