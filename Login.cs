using System;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class Login
    {
        private string _connectionString;

        public Login(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ValidateLogin(string username, string password, string role)
        {
            string query = "SELECT COUNT(*) FROM Register WHERE Username = @Username AND Password = @Password AND Role = @Role";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Role", role);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
