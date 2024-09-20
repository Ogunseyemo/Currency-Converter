using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOA_Currency_Converter
{
    public partial class AdminChangePassword : Form
    {
        public AdminChangePassword()
        {
            InitializeComponent();
        }

        // Event handler for the Close button
        private void CloseXbutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Createcurrencylabel_Click(object sender, EventArgs e)
        {
            AdminCreateCurrency createCurrencyForm = new AdminCreateCurrency();
            createCurrencyForm.Show();
            this.Hide();
        }

        private void Viewcurrencylabel_Click(object sender, EventArgs e)
        {
            AdminViewCurrency viewCurrencyForm = new AdminViewCurrency();
            viewCurrencyForm.Show();
            this.Hide();
        }

        private void Updatecurrencylabel_Click(object sender, EventArgs e)
        {
            AdminUpdateCurrency updateCurrencyForm = new AdminUpdateCurrency();
            updateCurrencyForm.Show();
            this.Hide();
        }

        private void Deletecurrencylabel_Click(object sender, EventArgs e)
        {
            AdminDeleteCurrency deleteCurrencyForm = new AdminDeleteCurrency();
            deleteCurrencyForm.Show();
            this.Hide();
        }

         private void Logoutlabel_Click(object sender, EventArgs e)
         {
             MOAConversion landingPage = new MOAConversion();
             landingPage.Show();
             this.Hide();
         }

        private void Changepasswordbutton_Click(object sender, EventArgs e)
        {
            string newPassword = PasswordtextBox.Text;
            string confirmPassword = ConfirmpasswordtextBox.Text;

            if (ValidatePassword(newPassword))
            {
                if (newPassword == confirmPassword)
                {
                    // Update password in the database
                    if (UpdateAdminPassword(newPassword))
                    {
                        MessageBox.Show("Password changed successfully!");
                        // Clear input fields
                        PasswordtextBox.Text = string.Empty;
                        ConfirmpasswordtextBox.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Error updating password. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Password must be at least 7 characters long and contain a combination of letters, numbers, and special characters.");
            }
        }

        private bool ValidatePassword(string password)
        {
            // Ensure password is at least 7 characters long and contains letters, numbers, and special characters
            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{7,}$");
            return regex.IsMatch(password);
        }

        private bool UpdateAdminPassword(string newPassword)
        {
            // Use your connection string here
            string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Admin SET Password = @Password WHERE AdminEmail = @AdminEmail";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@AdminEmail", "test@gmail.com");

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

    }
}
