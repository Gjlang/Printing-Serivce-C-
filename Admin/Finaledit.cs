using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Finaledit : Form
    {
        private string name;
        private string connectionString = Declare.ConnectionString; // Use the declared connection string

        public Finaledit(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void Finaledit_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Register WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Ensure the data is loaded into the respective controls
                        txtUsername.Text = reader["UserName"].ToString();
                        txtPassword.Text = reader["Password"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtFullname.Text = reader["Name"].ToString();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUserData();
        }

        private void UpdateUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Register SET UserName = @UserName, Password = @Password, Email = @Email, Phone = @Phone, [Name] = @NewName WHERE [Name] = @CurrentName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@NewName", txtFullname.Text); // Nama baru yang akan diperbarui
                    command.Parameters.AddWithValue("@CurrentName", name); // Nama saat ini untuk mengidentifikasi rekaman yang akan diperbarui
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user data: {ex.Message}");
            }
        }

        private void Finaledit_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updateform updateform    = new Updateform (name);
            updateform.ShowDialog();
            this.Close();
          
        }
    }
}
