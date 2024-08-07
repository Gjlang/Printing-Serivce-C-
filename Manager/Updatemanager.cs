﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_GROUP_29
{
    public partial class Updatemanager : Form
    {
        private readonly string username;
        private updateworkerclass Updateworkerclass;

        public Updatemanager(string username)
        {
            InitializeComponent();
            Updateworkerclass = new updateworkerclass(Declare.ConnectionString); // Use the declared connection string
            this.username = username;
            txtName2.Text = username; // Set the current username in the form field if needed
        }

        private void UpdateUserName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName2.Text))
            {
                PerformUpdate("Username", txtName2.Text);
            }
            else
            {
                MessageBox.Show("User Name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePhone_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhone2.Text))
            {
                PerformUpdate("Phone", txtPhone2.Text);
            }
            else
            {
                MessageBox.Show("Phone cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword2.Text))
            {
                PerformUpdate("Password", txtPassword2.Text);
            }
            else
            {
                MessageBox.Show("Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail2.Text))
            {
                PerformUpdate("Email", txtEmail2.Text);
            }
            else
            {
                MessageBox.Show("Email cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformUpdate(string columnName, string newValue)
        {
            try
            {
                Console.WriteLine($"Attempting to update {columnName} for user {username} to new value: {newValue}");
                if (UserExists(username))
                {
                    bool success = Updateworkerclass.UpdateWorker(username, columnName, newValue);
                    ShowUpdateResult(success);
                }
                else
                {
                    MessageBox.Show($"User {username} does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred in PerformUpdate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"An error occurred in PerformUpdate: {ex.Message}");
            }
        }

        private bool UserExists(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Updateworkerclass.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Register WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        int userCount = (int)command.ExecuteScalar();
                        Console.WriteLine($"User count for username {username}: {userCount}");
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in UserExists: {ex.Message}");
                return false;
            }
        }

        private void ShowUpdateResult(bool success)
        {
            if (success)
            {
                MessageBox.Show("User data updated successfully!");
                Console.WriteLine("User data updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update user data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Failed to update user data.");
            }
        }

        private void UpdateUserProfileForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerForm managerform = new ManagerForm(username);
            managerform.ShowDialog();
            this.Close();
        }

        private void Updateworker_Load(object sender, EventArgs e)
        {

        }

        private void Updatemanager_Load(object sender, EventArgs e)
        {

        }
    }
}