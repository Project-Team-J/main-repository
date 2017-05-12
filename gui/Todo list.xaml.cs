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
    /// Interaction logic for Todo_list.xaml
    /// </summary>
    public partial class Todo_list : Window
    {
        List<Task> list = new List<Task>();
        NameValueCollection todo_list = new NameValueCollection();
        WebClient client = new WebClient();
        public Todo_list()
        {
            InitializeComponent();
            using (client)
            {
                
                todo_list.Add("todo_list", "");
                byte[] response = client.UploadValues("http://localhost/", "POST", todo_list);
                String responseString = Encoding.UTF8.GetString(response);
                dynamic stuff = JsonConvert.DeserializeObject(responseString);
                //string ttt = stuff.task1.Task;
                string t = "task";
                int x = 0;
                Int32.TryParse(stuff.amount, out x);
                for (int i = 1; i < x; ++i)
                {
                    string tmp = t + i.ToString();
                    list.Add(new Task(stuff.tmp.Task, new DateTime(stuff.tmp.Date)));
                }
                list_task.Items.Add(list);

                //foreach (dynamic value in stuff)
                //{
                //    string tmp = t + i.ToString();
                //    list.Add(new Task(stuff[tmp].Task, new DateTime(stuff[tmp].Date)));
                //    ++i;
                //}
                //list_task.Items.Add(list);

            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Add_task t1 = new Add_task(list);
            t1.Show();
            list_task.Items.Add(list);
            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            todo_list.Add("delete", "");
            todo_list.Add("task", "test2");
            byte[] response = client.UploadValues("http://localhost/", "POST", todo_list);
            String responseString = Encoding.UTF8.GetString(response);
            responseString = responseString.Replace("[", "").Replace("]", "");
            dynamic stuff = JsonConvert.DeserializeObject(responseString);
            list_task.Items.Add(list);
        }
    }
    public class Task
    {
        private String task;
        private DateTime date;

        public Task(String task, DateTime date)
        {
            this.task = task;
            this.date = date;
        }
        public String TASK
        {
            get { return task; }
            set { task = value; }
        }
        public DateTime DATE
        {
            get { return date; }
            set { date = value; }
        }
    }
}
