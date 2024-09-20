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
    public partial class AdminUpdateCurrency : Form
    {
        // Connection string to your database
        private string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        public AdminUpdateCurrency()
        {
            InitializeComponent();
            LoadCurrencyCodes();
        }

        private void LoadCurrencyCodes()
        {
            string query = "SELECT CurrencyCode FROM Currency";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SelectcurrencycomboBox.Items.Add(reader["CurrencyCode"].ToString());
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void CurrencyamounttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, the decimal point, and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Allow only two decimal places
            if (char.IsDigit(e.KeyChar) && (sender as TextBox).Text.Contains("."))
            {
                string[] parts = (sender as TextBox).Text.Split('.');
                if (parts.Length > 1 && parts[1].Length >= 2)
                {
                    e.Handled = true;
                }
            }
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

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            if (SelectcurrencycomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a currency code.");
                return;
            }

            string selectedCurrencyCode = SelectcurrencycomboBox.SelectedItem.ToString();
            decimal amount;

            if (!decimal.TryParse(CurrencyamounttextBox.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            string query = "UPDATE Currency SET Amount = @Amount WHERE CurrencyCode = @CurrencyCode";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@CurrencyCode", selectedCurrencyCode);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Currency successfully updated.");
                            CurrencyamounttextBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while updating the currency.");
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
