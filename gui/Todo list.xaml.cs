﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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
                todo_list.Add("get_tasks", "");
                todo_list.Add("uname", Widgets.getUname());
                todo_list.Add("upass", Widgets.getUpass());
                byte[] response = client.UploadValues(Login.server, "POST", todo_list);
                String responseString = Encoding.UTF8.GetString(response);
                dynamic stuff = JsonConvert.DeserializeObject(responseString);
                int i = 1;
                String t = "task";
                int x = Convert.ToInt32(stuff.amount);
                String tmp = null;
                while (i <= x)
                {
                    tmp = t + i.ToString();
                    list.Add(new Task((string)stuff[tmp].Task, Convert.ToDateTime((string)stuff[tmp].Date), Convert.ToInt32((string)stuff[tmp].taskid)));
                    list_task.Items.Add(list[i - 1]);
                    ++i;
                }



            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            Add_task t1 = new Add_task(list, todo_list);
            this.Close();
            t1.Show();

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            
            bool flag = false;
            var selectedItems = list_task.SelectedItems;
            foreach (Task selectedItem in selectedItems)
            {
                todo_list = new NameValueCollection();
                todo_list.Add("todo_list", "");
                todo_list.Add("uname", Widgets.getUname());
                todo_list.Add("upass", Widgets.getUpass());
                todo_list.Add("delete", "");
                todo_list.Add("task_id", selectedItem.ID.ToString());
                byte[] res = client.UploadValues(Login.server, "POST", todo_list);
                flag = true;
                String responseString = Encoding.UTF8.GetString(res);
                Console.WriteLine(responseString);
            }
            if (flag)
            {
                this.Close();
                Todo_list td = new Todo_list();
                td.Show();
            }
            

        }
    }
    public class Task
    {
        private String task;
        private DateTime date;
        private int id;

        public Task(String task, DateTime date, int id)
        {
            this.task = task;
            this.date = date;
            this.id = id;
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
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
