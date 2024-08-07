using System;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class updateworkerclass
    {
        public readonly string connectionString;

        public updateworkerclass(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString => connectionString;

        public bool UpdateWorker(string username, string columnName, string newValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("SQL connection opened successfully.");

                    string query = $"UPDATE Register SET {columnName} = @NewValue WHERE Username = @Username";
                    Console.WriteLine($"Executing query: {query}");
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@Username", username);
                        Console.WriteLine("SQL command parameters added successfully.");

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"SQL command executed successfully. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in UpdateWorker: {ex.Message}");
                return false;
            }
        }
    }
}
