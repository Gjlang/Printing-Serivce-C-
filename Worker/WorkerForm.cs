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
    public partial class WorkerForm : Form
    {
        private readonly string username; // Make username private and readonly

        public WorkerForm(string username) // Accept username as a parameter in the constructor
        {
            InitializeComponent();
            this.username = username; // Assign the passed username to the private field
        }

        private void buttonReq_Click(object sender, EventArgs e)
        {
            new Workerrequest(username).Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Updateworker updateworker = new Updateworker(username);
            updateworker.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
