using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCContorl
{
    public partial class TaskForm : Form
    {
        public List<Task> _tasks = new List<Task>();

        public bool isOk = false;

        public bool taskExe;

        public TaskForm(List<Task> tasks, bool taskEx)
        {
            InitializeComponent();
            for (int i = 0; i < tasks.Count; i++)
            {
                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells[0].Value = tasks[i].no;
                dataGridView1.Rows[i].Cells[1].Value = tasks[i].name;
                dataGridView1.Rows[i].Cells[2].Value = tasks[i].time;
                dataGridView1.Rows[i].Cells[3].Value = tasks[i].cmd;
                dataGridView1.Rows[i].Cells[4].Value = tasks[i].remain;
                dataGridView1.Rows[i].Cells[5].Value = tasks[i].complete;
            }
            taskCheck.Checked = taskEx;
        }

        bool getTask()
        {
            _tasks.Clear();
            try
            {
                string str = "",str1="",str2="";
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        str = "m";
                    }
                    else
                    {
                        str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    }
                    if (dataGridView1.Rows[i].Cells[4].Value == null)
                    {
                        str1 = "0";
                    }
                    else
                    {
                        str1 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value == null)
                    {
                        str2 = "未执行";
                    }
                    else
                    {
                        str2 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    }
                    Task t = new Task(str,dataGridView1.Rows[i].Cells[1].Value.ToString(), 
                        dataGridView1.Rows[i].Cells[2].Value.ToString(),dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        str1,str2);
                    _tasks.Add(t);
                }
                isOk = true;
                taskExe = taskCheck.Checked;
                return true;
            }
            catch
            {
                MessageBox.Show("保存出错，请检查数据！");
                return false;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (getTask())
                this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculateTiemr_Tick(object sender, EventArgs e)
        {
            try
            {
                string nowTime = DateTime.Now.ToString("HH-mm-ss");
                string[] ts = nowTime.Split('-');
                int h1 = int.Parse(ts[0]);
                int m1 = int.Parse(ts[1]);
                int s1 = int.Parse(ts[2]);
                for (int i = 0; i <dataGridView1.Rows.Count; i++)
                {
                    ts = dataGridView1.Rows[i].Cells[2].Value.ToString().Split(' ');
                    int h2 = int.Parse(ts[1].Split('-')[0]);
                    int m2 = int.Parse(ts[1].Split('-')[1]);
                    int s2 = int.Parse(ts[1].Split('-')[2]);

                    dataGridView1.Rows[i].Cells[4].Value = (((h2 - h1) * 60 + (m2 - m1)) * 60 + s2 - s1).ToString();
                }
            }
            catch
            { }
        }
    }
}
