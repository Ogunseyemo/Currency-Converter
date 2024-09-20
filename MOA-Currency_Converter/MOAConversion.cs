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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MOA_Currency_Converter
{
    public partial class MOAConversion : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        public MOAConversion()
        {
            InitializeComponent();
            LoadCurrencyCodes();
        }

        private void AdminLoginbutton_Click(object sender, EventArgs e)
        {

            // Create an instance of AdminLogin form
            AdminLogin adminLogin = new AdminLogin();

            // Show the AdminLogin form
            adminLogin.Show();

            // Hide the current form (MOAConversion)
            this.Hide();

        }

        private void CloseXbutton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadCurrencyCodes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CurrencyCode FROM Currency";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable currencyTable = new DataTable();
                adapter.Fill(currencyTable);

                FromcomboBox.DataSource = currencyTable;
                FromcomboBox.DisplayMember = "CurrencyCode";
                FromcomboBox.ValueMember = "CurrencyCode";

                TocomboBox.DataSource = currencyTable.Copy();
                TocomboBox.DisplayMember = "CurrencyCode";
                TocomboBox.ValueMember = "CurrencyCode";
            }
        }











        public string ConvertCurrency(string amountText, string fromCurrency, string toCurrency)
        {
            if (!decimal.TryParse(amountText, out decimal amount))
            {
                return "Please enter a valid amount.";
            }

            decimal conversionRate = GetConversionRate(fromCurrency, toCurrency);
            if (conversionRate == 0)
            {
                return "Conversion rate not found.";
            }
            decimal convertedAmount = Math.Round(amount * conversionRate, 2);

            return $"1 {fromCurrency} = {conversionRate:F2} {toCurrency}\n{amount:F2} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
        }

        private void Convertbutton_Click(object sender, EventArgs e)
        {
            string result = ConvertCurrency(AmounttextBox.Text, FromcomboBox.SelectedValue.ToString(), TocomboBox.SelectedValue.ToString());
            if (result.Contains("Please enter a valid amount.") || result.Contains("Conversion rate not found."))
            {
                MessageBox.Show(result);
            }
            else
            {
                Resultlabel.Text = result;
                Resultlabel.Visible = true;
            }
        }
















        /*
        private void Convertbutton_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(AmounttextBox.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            string fromCurrency = FromcomboBox.SelectedValue.ToString();
            string toCurrency = TocomboBox.SelectedValue.ToString();

            decimal conversionRate = GetConversionRate(fromCurrency, toCurrency);
            if (conversionRate == 0)
            {
                MessageBox.Show("Conversion rate not found.");
                return;
            }
            decimal convertedAmount = Math.Round(amount * conversionRate, 2);

            Resultlabel.Text = $"1 {fromCurrency} = {conversionRate:F2} {toCurrency}\n{amount:F2} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
            Resultlabel.Visible = true;

        }*/

        private decimal GetConversionRate(string fromCurrency, string toCurrency)
        {
            decimal fromRate = GetCurrencyRate(fromCurrency);
            decimal toRate = GetCurrencyRate(toCurrency);

            if (fromRate == 0 || toRate == 0)
            {
                return 0;
            }

            return toRate / fromRate;
        }

        private decimal GetCurrencyRate(string currencyCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Amount FROM Currency WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);

                connection.Open();
                object result = cmd.ExecuteScalar();
                connection.Close();

                if (result != null && decimal.TryParse(result.ToString(), out decimal rate))
                {
                    return rate;
                }
                return 0;
            }
        }

        private void ExchangearrowspictureBox_Click(object sender, EventArgs e)
        {
            var temp = FromcomboBox.SelectedValue;
            FromcomboBox.SelectedValue = TocomboBox.SelectedValue;
            TocomboBox.SelectedValue = temp;
        }

        private void AmounttextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, the decimal point, and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Allow only two decimal places
            if (char.IsDigit(e.KeyChar) && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                string[] parts = (sender as System.Windows.Forms.TextBox).Text.Split('.');
                if (parts.Length > 1 && parts[1].Length >= 2)
                {
                    e.Handled = true;
                }
            }
        }
    }
}