using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_GROUP_29
{
    public partial class ServiceReport : Form
    {
        private string connectionString = Declare.ConnectionString; // Use the declared connection string
        private readonly string name;

        public ServiceReport(string name)
        {
            InitializeComponent();
            this.Load += new EventHandler(ServiceRequestForm_Load);
            button1.Click += new EventHandler(button1_Click);
            this.name = name;
        }

        private void ServiceRequestForm_Load(object sender, EventArgs e)
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

        private void SearchData(string name)
        {
            try
            {
                DataTable filteredTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Requests WHERE Name = @Name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(filteredTable);
                    }
                }

                if (filteredTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = filteredTable;
                }
                else
                {
                    MessageBox.Show("No records found for the specified name.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null; // Clear the DataGridView if no records are found
                }
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
                string name = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a name to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SearchData(name);
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

        private void ServiceReport_Load(object sender, EventArgs e)
        {

        }
    }
}
