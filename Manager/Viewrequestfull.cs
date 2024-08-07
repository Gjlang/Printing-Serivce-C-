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
    public partial class Viewrequestfull : Form
    {
        private readonly string username; // Add private readonly string field for username

        public Viewrequestfull(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Viewrequestfull_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet.Requests' table. You can move, or remove it, as needed.
            this.requestsTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Requests);
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Register);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerForm managerForm = new ManagerForm(username);
            managerForm.ShowDialog();  
            this.Close();
        }
    }
}
