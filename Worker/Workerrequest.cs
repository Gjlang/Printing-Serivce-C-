using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Workerrequest : Form
    {
        private readonly string connectionString = Declare.ConnectionString;
        private readonly string username; // Add private field for username


        public Workerrequest(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Workerrequest_Load(object sender, EventArgs e)
        {
            LoadDataGridViewData();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            // Add options to the ComboBox
            comboBox1.Items.Add("In progress");
            comboBox1.Items.Add("Delayed");
            comboBox1.Items.Add("Finished");
        }

        private void LoadDataGridViewData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Requests";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string workerName = textBox1.Text;
            string bookingID = textBox2.Text;
            string taskStatus = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(workerName) || string.IsNullOrEmpty(bookingID) || string.IsNullOrEmpty(taskStatus))
            {
                MessageBox.Show("Please enter Worker Name, Booking ID, and select a Task Status.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Update worker and status in Requests table based on Booking ID
                    string updateRequestQuery = "UPDATE Requests SET WorkerName = @WorkerName, Confirmation = @Confirmation WHERE BookingID = @BookingID";
                    using (SqlCommand cmd = new SqlCommand(updateRequestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkerName", workerName);
                        cmd.Parameters.AddWithValue("@Confirmation", taskStatus);
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the provided Booking ID.");
                        }
                    }

                    LoadDataGridViewData(); // Refresh the data grid view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle Worker Name text change if needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle Booking ID text change if needed
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle ComboBox selection change if needed
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event if needed
        }


        private void button1_Click(object sender, EventArgs e)
        {
            WorkerForm workerForm = new WorkerForm(username);
            workerForm.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}