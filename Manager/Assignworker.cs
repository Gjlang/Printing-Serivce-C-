using OOP_GROUP_29.Manager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Assignworker : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-13KUA0E2\\SQLEXPRESS;Initial Catalog=OOP_DATABASE_G29;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private readonly string username; // Add private readonly string field for username


        public Assignworker(string username)
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadDataGridViewData();
            this.username = username;
        }

        private void LoadComboBoxData()
        {
            // Add options to the ComboBox
            comboBox1.Items.Add("In progress");
            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Completed");
        }

        private void LoadDataGridViewData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Requests"; // Adjust your query as needed
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable(username);
                    dataAdapter.Fill(dataTable);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string workerName = textBox1.Text;
            string confirmationStatus = comboBox1.SelectedItem?.ToString();
            string bookingID = textBox2.Text;

            if (string.IsNullOrEmpty(workerName) || string.IsNullOrEmpty(confirmationStatus) || string.IsNullOrEmpty(bookingID))
            {
                MessageBox.Show("Please enter Worker Name, select Confirmation Status, and enter a valid Booking ID.");
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
                        cmd.Parameters.AddWithValue("@Confirmation", confirmationStatus);
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data updated successfully.");
                    LoadDataGridViewData(); // Refresh the data grid view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Workertasks1 workertasks1 = new Workertasks1(username);
            workertasks1.ShowDialog();
            this.Close();
        }

        private void Assignworker_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerForm managerform = new ManagerForm(username);    
            managerform.Show();
            this.Close();
        }
    }
}
