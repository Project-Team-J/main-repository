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
using static ProjectJ.Task;
using static ProjectJ.Todo_list;

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
            todo_list.Add("add", "");
            todo_list.Add("task", task.Text);
            todo_list.Add("date", dates.ToString());


        }

        public void adding_Click(object sender, RoutedEventArgs e)
        {

            list.Add(new Task(task.Text, Convert.ToDateTime(dates.ToString())));
            byte[] response = client.UploadValues("http://localhost/", "POST", todo_list);
            this.Close();
            
        }
    }
}
