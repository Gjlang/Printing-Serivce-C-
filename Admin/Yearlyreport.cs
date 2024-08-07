using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Yearlyreport : Form
    {
        private string connectionString = Declare.ConnectionString; // Use the declared connection string
        private readonly string name;

        public Yearlyreport(string name)
        {
            InitializeComponent();
            this.Load += new EventHandler(Yearlyreport_Load);
            button1.Click += new EventHandler(button1_Click);
            this.name = name;
        }

        private void Yearlyreport_Load(object sender, EventArgs e)
        {
            // You can load initial data or leave it blank
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int year;
                if (int.TryParse(textBox1.Text, out year))
                {
                    LoadYearlyReportData(year);
                }
                else
                {
                    MessageBox.Show("Please enter a valid year.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadYearlyReportData(int year)
        {
            try
            {
                DataTable reportData = GetYearlyReportData(year);
                dataGridView1.DataSource = reportData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetYearlyReportData(int year)
        {
            string query = @"
                SELECT MONTH(Date) AS Month, SUM(Fees) AS TotalIncome
                FROM Requests
                WHERE YEAR(Date) = @Year
                GROUP BY MONTH(Date)
                ORDER BY MONTH(Date)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Add MonthName column and populate it
                dataTable.Columns.Add("MonthName", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    row["MonthName"] = GetMonthName(Convert.ToInt32(row["Month"]));
                }

                // Reorder columns to make MonthName the first column
                DataTable reorderedTable = dataTable.Clone();
                reorderedTable.Columns["MonthName"].SetOrdinal(0);

                foreach (DataRow row in dataTable.Rows)
                {
                    reorderedTable.ImportRow(row);
                }

                return reorderedTable;
            }
        }

        private string GetMonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report = new Report(name);
            report.ShowDialog();
            this.Close();
        }
    }
}
