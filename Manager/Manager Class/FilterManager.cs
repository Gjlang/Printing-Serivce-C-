using System;
using System.Data;
using System.Data.SqlClient;

namespace OOP_GROUP_29.Admin
{
    internal class FilterManager
    {
        public string ConnectionString { get; set; } = Declare.ConnectionString;

        public DataTable FilterDataByWorkerName(string workerName)
        {
            DataTable filteredTable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Requests WHERE WorkerName = @WorkerName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WorkerName", workerName);

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
