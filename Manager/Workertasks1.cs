using OOP_GROUP_29.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_GROUP_29.Manager
{
    public partial class Workertasks1 : Form
    {
        private readonly string username; // Add private readonly string field for username
        private FilterManager filterManager;

        public Workertasks1(string username)
        {
            InitializeComponent();
            filterManager = new FilterManager();
            this.username = username;
        }

        private void Workertasks1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet.Requests' table. You can move, or remove it, as needed.
            this.requestsTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Requests);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assignworker assignworker = new Assignworker(username);
            assignworker.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string workerName = textBox1.Text;

            if (string.IsNullOrWhiteSpace(workerName))
            {
                MessageBox.Show("Please enter a worker name.");
                return;
            }

            try
            {
                DataTable results = filterManager.FilterDataByWorkerName(workerName);
                dataGridView1.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}");
            }
        }
    }
}
