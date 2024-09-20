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
    public partial class AdminCreateCurrency : Form
    {
        // Connection string to your database
        private string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        public AdminCreateCurrency()
        {
            InitializeComponent();
        }

        private void CurrencyamounttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters (like backspace) and digits
            if (char.IsControl(e.KeyChar))
            {
                return; // Allow control characters
            }

            // Allow digits and decimal point
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                // Allow only one decimal point
                if (e.KeyChar == '.')
                {
                    // Check if the text already contains a decimal point
                    if ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
                    {
                        e.Handled = true; // Prevent adding another decimal point
                    }
                }
                return; // Allow digits and single decimal point
            }

            // Block any other characters
            e.Handled = true;
        }

        private void CurrencyamounttextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            // Check if the text contains a decimal point
            if (text.Contains('.'))
            {
                // Limit the number of decimal places to 2
                int decimalIndex = text.IndexOf('.');
                if (text.Length > decimalIndex + 3) // 2 decimal places + 1 for the decimal point
                {
                    textBox.Text = text.Substring(0, decimalIndex + 3);
                    textBox.SelectionStart = textBox.Text.Length; // Move cursor to the end
                }
            }
        }

        private void CurrencycodetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control characters (like backspace) and both upper and lower case letters
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Createbutton_Click(object sender, EventArgs e)
        {
            // Get data from text boxes
            string currencyName = CurrencynametextBox.Text;
            string currencyCode = CurrencycodetextBox.Text.ToUpper(); // Convert to upper case
            decimal amount;

            // Validate amount
            if (!decimal.TryParse(CurrencyamounttextBox.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            // SQL query to insert data
            string query = "INSERT INTO Currency (CurrencyName, CurrencyCode, Amount) VALUES (@CurrencyName, @CurrencyCode, @Amount)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@CurrencyName", currencyName);
                        command.Parameters.AddWithValue("@CurrencyCode", currencyCode);
                        command.Parameters.AddWithValue("@Amount", amount);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Currency successfully added.");
                            // Clear input fields
                            CurrencynametextBox.Text = string.Empty;
                            CurrencycodetextBox.Text = string.Empty;
                            CurrencyamounttextBox.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding the currency.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        // Event handler for the Close button
        private void CloseXbutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Changepassword_label_Click(object sender, EventArgs e)
        {
            AdminUpdateCurrency updateCurrencyForm = new AdminUpdateCurrency();
            updateCurrencyForm.Show();
            this.Hide();
        }

        private void Logoutlabel_Click(object sender, EventArgs e)
        {
            MOAConversion landingPage = new MOAConversion();
            landingPage.Show();
            this.Hide();
        }
    }
}
