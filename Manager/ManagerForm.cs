using OOP_GROUP_29.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class ManagerForm : Form
    {
        private readonly string username; 

        public ManagerForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assignworker assignworker = new Assignworker(username);
            assignworker.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Viewrequestfull viewrequestfull = new Viewrequestfull(username);
            viewrequestfull.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updatemanager updatemanager = new Updatemanager(username);
            updatemanager.Show();
            this.Close();
        }
    }
}
