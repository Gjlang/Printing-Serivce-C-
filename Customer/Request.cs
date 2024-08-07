using OOP_GROUP_29;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_GROUP_29
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Customer_calculation customercs = new Customer_calculation();
                List<Services> services = customercs.GetServices();

                if (services.Count == 0)
                {
                    MessageBox.Show("No services found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int quantity = int.TryParse(textBox1.Text, out quantity) ? quantity : 1;
                string name = textBox2.Text;
                bool isUrgent = checkBox1.Checked; // Define isUrgent once
                bool servicesFound = false;
                DateTime date = DateTime.Now;
                string bookingID = BookingIDGenerator.GenerateBookingID();




                foreach (Services service in services)
                {
                    if (service.ServiceType == comboBox1.Text)
                    {
                        double totalCost = customercs.CalculateTotalCost(service, quantity);

                        if (isUrgent)
                        {
                            totalCost *= 1.3; // Add 30%
                        }

                        string status = isUrgent ? "Urgent" : "Not Urgent";

                        MessageBox.Show($"Booking ID: {bookingID}\nID: {service.ServiceID}\nName: {name}\nFee: {service.Fees:C}\nQuantity: {quantity}\nTotal Cost: {totalCost:C}\nStatus: {status}\nDate: {date}", "Service Cost", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        Inputdata inputdataHandler = new Inputdata();

                        inputdataHandler.AddRequest(bookingID, name, quantity, service.ServiceType, totalCost, status, date, "New Assigment");

                        servicesFound = true;
                        break;
                    }
                }

                if (!servicesFound)
                {
                    MessageBox.Show("Service not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input format is not valid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Request_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oOP_DATABASE_G29DataSet.Services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.oOP_DATABASE_G29DataSet.Services);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm(Name);
            customerForm.ShowDialog();
            this.Close();
        }
    }

}


