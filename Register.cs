using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Assuming you're using WinForms for your GUI

namespace OOP_GROUP_29
{
    public class Register
    {
        public static void AddUser(string name, int phone, string email, string username, string password, string role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-13KUA0E2\\SQLEXPRESS;Initial Catalog=OOP_DATABASE_G29;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Register] (Name, Phone, Email, Username, Password, Role) VALUES (@Name, @Phone, @Email, @Username, @Password, @Role)", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role); // Add the Role parameter here
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data added successfully");

                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
