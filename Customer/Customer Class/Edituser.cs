using System;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class Editiuser
    {
        private readonly string connectionString;

        public Editiuser(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool UpdateName(string username, string newName)
        {
            return UpdateUserData(username, "Name", newName);
        }

        public bool UpdatePassword(string username, string newPassword)
        {
            return UpdateUserData(username, "Password", newPassword);
        }

        public bool UpdateEmail(string username, string newEmail)
        {
            return UpdateUserData(username, "Email", newEmail);
        }

        public bool UpdatePhone(string username, string newPhone)
        {
            return UpdateUserData(username, "Phone", newPhone);
        }

        private bool UpdateUserData(string username, string columnName, string newValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"UPDATE Register SET {columnName} = @NewValue WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Query executed: {query}, Username: {username}, NewValue: {newValue}, Rows Affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL error occurred: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}