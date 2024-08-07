using System;
using System.Data;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class Filteryear
    {
        public string ConnectionString { get; set; } = "Data Source=LAPTOP-13KUA0E2\\SQLEXPRESS;Initial Catalog=OOP_DATABASE_G29;Integrated Security=True;TrustServerCertificate=True";

        public DataTable FilterDataByDate(string date)
        {
            DataTable filteredTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Requests WHERE Name = @Date";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", date);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(filteredTable);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"SQL Error filtering data: {sqlEx.Message}", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error filtering data: {ex.Message}", ex);
            }

            return filteredTable;
        }
    }
}
