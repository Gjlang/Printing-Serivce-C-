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
    public partial class AdminForm : Form
    {
        private readonly string name;

        public AdminForm(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register_page register_Page = new Register_page(name);
            register_Page.Show();
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Updateform updateform = new Updateform(name);
            updateform.Show();
            this.Close();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Report report = new Report(name);   
            report.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main(); 
            main.Show();
            this.Close();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    } 
}
