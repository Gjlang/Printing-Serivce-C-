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
    public partial class View : Form
    {
        private readonly string username; // Add private readonly string field for username

        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet4.Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Services);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(username);
            customerForm.ShowDialog();
            this.Close();
        }
    }
}
