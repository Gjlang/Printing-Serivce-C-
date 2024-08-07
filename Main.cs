using System; // Importing the System namespace
using System.Windows.Forms; // Importing the Windows Forms namespace

namespace OOP_GROUP_29 // Namespace declaration
{
    public partial class Main : Form // Class declaration
    {
        public Main() // Constructor
        {
            InitializeComponent(); // Initialize form components
        }

        private void button1_Click(object sender, EventArgs e) // Event handler for button1 click event
        {
            // No action
        }

        private void button2_Click(object sender, EventArgs e) // Event handler for button2 click event
        {
            Loginpage login_Page = new Loginpage(); // Create a new instance of Loginpage
            login_Page.Show(); // Show the Loginpage form
            this.Hide(); // Hide the current form (Main)
        }

        private void label1_Click(object sender, EventArgs e) // Event handler for label1 click event
        {
            // No action
        }

        private void Main_Load(object sender, EventArgs e) // Event handler for Main form load event
        {
            // No action
        }
    }
}
