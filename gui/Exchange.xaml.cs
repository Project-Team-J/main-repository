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
using Newtonsoft.Json;
using System.Collections;



namespace ProjectJ
{
    /// <summary>
    /// Interaction logic for Exchange.xaml
    /// </summary>
    public partial class Exchange : Window
    {
        public Exchange()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            
                string getcombo1 = (comboBox1.SelectedItem as ComboBoxItem).Content.ToString();
                string getcombo2 = (comboBox2.SelectedItem as ComboBoxItem).Content.ToString();

                WebClient client = new WebClient();
                NameValueCollection exchangeInfo = new NameValueCollection();
                Boolean flag=true;
                foreach (char c in Amount.Text)
                {
                    if ((c < '0' || c > '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || c == ' ')
                     {
                        result.Text = "Please enter an appropriat number --->";
                        flag = false;
                     }
                 }


            if (flag != false)
            {
                exchangeInfo.Add("exchange", "");
                exchangeInfo.Add("from", getcombo1);//------saving the "from" rate.-------
                exchangeInfo.Add("to", getcombo2);// ------saving the "to" rate.--------
                exchangeInfo.Add("amount", Amount.Text);//----- saving the amount the user want to exchange-------
                byte[] response = client.UploadValues("http://localhost/", "POST", exchangeInfo);//--------sending the details to the php code ang getting the result---------
                var responseString = Encoding.UTF8.GetString(response);
                dynamic stuff = JsonConvert.DeserializeObject(responseString);
                result.Text = stuff.result;//----- print the result we got-------
            }
                






           

        }
    }
}