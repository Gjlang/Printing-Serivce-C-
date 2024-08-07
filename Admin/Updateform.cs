using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Updateform : Form
    {
        private readonly string name;
        private Filter filter;

        public Updateform(string name)
        {
            InitializeComponent();
            filter = new Filter { ConnectionString = Declare.ConnectionString }; // Use the declared connection string
            this.name = name;
        }

        private void Updateform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Register);
        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            string name = Username.Text; // Assume you have a TextBox for the username.
            DataTable result = filter.FilterDataByName(name);

            if (result.Rows.Count > 0)
            {
                MessageBox.Show("Name exists.");
                Finaledit finaledit = new Finaledit(name);
                finaledit.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Name does not exist.");
            }
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdminForm adminform = new AdminForm(name);
            adminform.ShowDialog();
            this.Close();
        }
    }
}
