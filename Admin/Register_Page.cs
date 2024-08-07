using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Register_page : Form
    {
        private readonly string name;

        public Register_page(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            int phone = 0;
            int.TryParse(textBoxPhone.Text, out phone);
            string email = textBoxEmail.Text;
            string username = textBoxLogName.Text;
            string password = textBoxPass.Text;
            string role = textBox1.Text;


            try
            {
                // Call the AddUser method to insert the data into the database
                Register.AddUser(name, phone, email, username, password, role);

                // Display a message box to indicate successful registration
                MessageBox.Show("Thanks for registering!", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(name); 
            adminForm.Show();
            this.Close();
        }

        private void Register_page_Load(object sender, EventArgs e)
        {

        }
    }
}
