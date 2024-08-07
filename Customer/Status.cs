using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Status : Form
    {
        private Filter dataFilter;

        public Status()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form3_Load);
            button1.Click += new EventHandler(Button1_Click);
            dataFilter = new Filter(); // Automatically uses the connection string from Declare
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dataFilter.ConnectionString))
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
                DataTable filteredTable = dataFilter.FilterDataByName(name);

                // Debugging: Check if filteredTable is null or has rows
                if (filteredTable == null)
                {
                    MessageBox.Show("No data returned from the search query.");
                }
                else if (filteredTable.Rows.Count == 0)
                {
                    MessageBox.Show("No matching records found.");
                }
                else
                {
                    dataGridView1.DataSource = filteredTable;
                    MessageBox.Show($"{filteredTable.Rows.Count} record(s) found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SearchData(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Status_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            CustomerForm customer = new CustomerForm(Name);
            customer.ShowDialog();
            this.Close();
        }
    }
}
