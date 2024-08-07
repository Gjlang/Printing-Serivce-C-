using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29.Admin
{
    public partial class CustomerReport : Form
    {
        // Use the connection string from the Declare class
        private string connectionString = Declare.ConnectionString;
        private readonly string name;


        public CustomerReport(string name)
        {
            InitializeComponent();
            this.Load += new EventHandler(CustomerReport_Load);
            button1.Click += new EventHandler(button1_Click);
            this.name = name;
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Requests";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error loading data: {sqlEx.Message}\n{sqlEx.StackTrace}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchData(string date)
        {
            try
            {
                DataTable filteredTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Requests WHERE CONVERT(VARCHAR, Date, 101) = @Date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DateTime parsedDate;
                        if (DateTime.TryParse(date, out parsedDate))
                        {
                            cmd.Parameters.AddWithValue("@Date", parsedDate.ToString("MM/dd/yyyy"));
                        }
                        else
                        {
                            throw new FormatException("Invalid date format. Please use MM/dd/yyyy format.");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(filteredTable);
                    }
                }

                dataGridView1.DataSource = filteredTable;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Input format is not valid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error searching data: {sqlEx.Message}\n{sqlEx.StackTrace}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(date))
                {
                    MessageBox.Show("Please enter a date to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SearchData(date);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report = new Report(name);
            report.ShowDialog();
            this.Close();
        }
    }
}
