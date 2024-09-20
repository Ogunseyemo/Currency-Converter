using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOA_Currency_Converter
{
    public partial class AdminLogin : Form
    {
        // Connection string to connect to your SQL Server database
        private readonly string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";
        private Timer timer;
        private string password = "";
        private int currentPosition = 0;
        private int lastCharIndex = -1;
        public AdminLogin()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 500; // Set the interval to 500 milliseconds
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Replace the last character with asterisk
            if (lastCharIndex >= 0)
            {
                passwordtextBox.Text = new string('*', password.Length);
                passwordtextBox.SelectionStart = currentPosition;
                lastCharIndex = -1;
            }
        }



        private void PasswordtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                // Handle backspace key
                if (e.KeyChar == (char)Keys.Back && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    currentPosition--;
                }
            }
            else
            {
                // Append the new character to the password
                password += e.KeyChar;
                currentPosition++;
            }

            // Show the last typed character and start/restart the timer
            lastCharIndex = password.Length - 1;
            passwordtextBox.Text = new string('*', lastCharIndex) + password[lastCharIndex];
            passwordtextBox.SelectionStart = currentPosition;

            // Start or restart the timer
            timer.Stop();
            timer.Start();

            // Prevent the character from being added twice
            e.Handled = true;
        }



        // Event handler for the Login button
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string adminEmail = emailtextBox.Text;

            if (AuthenticateAdmin(adminEmail, password))
            {
                // Login successful
                // MessageBox.Show("Login successful!");
                // Navigate to the admin panel or dashboard
                AdminChangePassword adminPanel = new AdminChangePassword();
                adminPanel.Show();
                this.Hide();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        // Method to authenticate admin
        private bool AuthenticateAdmin(string adminEmail, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Admin WHERE AdminEmail = @AdminEmail AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@AdminEmail", adminEmail);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                return count == 1;
            }
        }

        // Event handler for the Back button
        private void BackarrowpictureBox_Click(object sender, EventArgs e)
        {
                 // Navigate to the landing page
                 // Assuming you have a Form for the landing page
                 MOAConversion landingPage = new MOAConversion();
                 landingPage.Show();
                 this.Hide();
        }

        // Event handler for the Close button
        private void CloseXbutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}