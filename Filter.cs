using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public class Filter
    {
        public string ConnectionString { get; set; } = Declare.ConnectionString;

        public DataTable FilterDataByName(string name)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    // Change the table name to `Requests` if that's where you want to search
                    string query = "SELECT * FROM Requests WHERE Name LIKE @Name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", "%" + name + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}");
            }

            return dataTable;
        }
    }
}
