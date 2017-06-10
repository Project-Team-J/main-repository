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
    /// Interaction logic for Add_task.xaml
    /// </summary>
    public partial class Add_task : Window
    {
        WebClient client = new WebClient();
        List<Task> list = new List<Task>();
        NameValueCollection todo_list = new NameValueCollection();


        public Add_task(List<Task> list, NameValueCollection todo_list)
        {
            InitializeComponent();
            this.todo_list = todo_list;

  


        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            todo_list.Add("add", "");
            todo_list.Add("task", task.Text);
            String d = "" + dates.SelectedDate.Value.Year + "-" + dates.SelectedDate.Value.Month + "-" + dates.SelectedDate.Value.Day;
            todo_list.Add("date", d);
            byte[] response = client.UploadValues(Login.server, "POST", todo_list);
            this.Close();
            Todo_list td = new Todo_list();
            td.Show();
        }
    }
}
