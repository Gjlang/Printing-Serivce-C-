using System; // Importing the System namespace for basic functionality
using System.Data.SqlClient; // Importing the namespace for SQL Server data access
using System.Windows.Forms; // Importing the namespace for Windows Forms functionality

namespace OOP_GROUP_29 // Namespace declaration for the project
{
    public partial class Loginpage : Form // Class declaration for the Loginpage form
    {
        public Loginpage() // Constructor for the Loginpage form
        {
            InitializeComponent(); // Method to initialize components of the form
        }

        private void button1_Click(object sender, EventArgs e) // Event handler for the button click event
        {
            try // Handling potential exceptions
            {
                string username = textBox1.Text; // Retrieving username from textbox
                string password = textBox2.Text; // Retrieving password from textbox

                string connectionString = Declare.ConnectionString; // Retrieving connection string

                using (SqlConnection con = new SqlConnection(connectionString)) // Creating SQL connection
                {
                    con.Open(); // Opening connection to the database

                    string query = "SELECT Role FROM Register WHERE Username = @username AND Password = @password"; // SQL query to check username and password

                    using (SqlCommand cmd = new SqlCommand(query, con)) // Creating SQL command
                    {
                        cmd.Parameters.AddWithValue("@username", username); // Adding username parameter to the SQL command
                        cmd.Parameters.AddWithValue("@password", password); // Adding password parameter to the SQL command

                        using (SqlDataReader dr = cmd.ExecuteReader()) // Executing SQL command and reading results
                        {
                            if (dr.Read()) // Checking if a record exists
                            {
                                string role = dr["Role"].ToString(); // Retrieving user role

                                MessageBox.Show("Login successful!"); // Showing success message

                                switch (role) // Checking user role and navigating to appropriate form
                                {
                                    case "Admin":
                                        AdminForm adminForm = new AdminForm(username);
                                        adminForm.Show();
                                        break;
                                    case "Manager":
                                        ManagerForm managerForm = new ManagerForm(username); // Passing username to ManagerForm
                                        managerForm.Show();
                                        break;
                                    case "Worker":
                                        WorkerForm workerForm = new WorkerForm(username); // Passing username to WorkerForm
                                        workerForm.Show();
                                        break;
                                    case "Customer":
                                        CustomerForm customerForm = new CustomerForm(username); // Passing username to CustomerForm
                                        customerForm.Show();
                                        break;
                                    default:
                                        MessageBox.Show("Invalid role!"); // Showing error message for invalid role
                                        break;
                                }

                                this.Hide(); // Hiding the Loginpage form after successful login
                            }
                            else // If no record found with provided username and password
                            {
                                MessageBox.Show("Invalid username or password. Please try again."); // Showing error message
                                textBox2.Clear(); // Clearing password textbox
                                textBox1.Focus(); // Setting focus to username textbox
                            }
                        }
                    }
                }
            }
            catch (SqlException ex) // Catching SQL Server related exceptions
            {
                MessageBox.Show("An error occurred accessing the database: " + ex.Message); // Showing error message
            }
        }

        private void Loginpage_Load(object sender, EventArgs e) // Event handler for form load event
        {
            // No specific action required on form load
        }
    }
}
