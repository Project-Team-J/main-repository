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
            using (WebClient wc = new WebClient())
            {
                // need to change in server to oop.
                Label_word.Content = wc.DownloadString("http://localhost/normalization/wordoftheday");
            }
        }
    }
}
