using System;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class UserUpdater
    {
        private readonly string connectionString;

        public UserUpdater(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString => connectionString;

        public bool UpdateUser(string username, string columnName, string newValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("SQL connection opened successfully.");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error opening SQL connection: {ex.Message}");
                        return false;
                    }

                    string query = $"UPDATE Register SET {columnName} = @NewValue WHERE Username = @Username";
                    Console.WriteLine($"Executing query: {query}");
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@NewValue", newValue);
                            command.Parameters.AddWithValue("@Username", username);
                            Console.WriteLine("SQL command parameters added successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error adding parameters to SQL command: {ex.Message}");
                            return false;
                        }

                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"SQL command executed successfully. Rows affected: {rowsAffected}");
                            return rowsAffected > 0;
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine($"Error executing SQL command: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in UpdateUser: {ex.Message}");
                return false;
            }
        }
    }
}
