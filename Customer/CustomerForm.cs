using System;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class CustomerForm : Form
    {
        private readonly string username;

        public CustomerForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // Code to execute when the form loads
            // You can display the username or use it as needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            request.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View view = new View();
            view.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Status status = new Status();
            status.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateUserProfileForm updateUserProfileForm = new UpdateUserProfileForm(username);
            updateUserProfileForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
