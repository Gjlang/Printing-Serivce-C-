using OOP_GROUP_29.Admin;
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
    public partial class Report : Form
    {
        private readonly string name;

        public Report(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void buttonYearly_Click(object sender, EventArgs e)
        {
            Yearlyreport yerreport = new Yearlyreport(name);
            yerreport.ShowDialog();
            this.Close();
        }

        private void buttonCustReport_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerReport customerForm = new CustomerReport(name);
            customerForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReport serviceForm = new ServiceReport(name);
            serviceForm.ShowDialog();
            this.Close();

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(name);  
            adminForm.ShowDialog();
            this.Close();
        }
    }
}
