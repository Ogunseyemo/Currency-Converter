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
    public partial class AdminViewCurrency : Form
    {
        // Connection string to connect to your SQL Server database
        private readonly string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        public AdminViewCurrency()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CurrencyCode FROM Currency";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                SelectcurrencycomboBox.DisplayMember = "CurrencyCode";
                SelectcurrencycomboBox.ValueMember = "CurrencyCode";
                SelectcurrencycomboBox.DataSource = dt;
            }
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            if (SelectcurrencycomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a currency.");
                return;
            }

            string selectedCurrency = SelectcurrencycomboBox.SelectedValue.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CurrencyName, CurrencyCode, Amount FROM Currency WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", selectedCurrency);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string currencyName = reader["CurrencyName"].ToString();
                    string currencyCode = reader["CurrencyCode"].ToString();
                    string currencyRate = reader["Amount"].ToString();

                    Resultlabel.Text = $"Currency Name = {currencyName}\n" +
                                       $"Currency Code = {currencyCode}\n" +
                                       $"Currency Rate per US Dollar = {currencyRate}";
                    Resultlabel.Visible = true; // Make sure the label is visible
                }
                else
                {
                    Resultlabel.Text = "Currency not found.";
                    Resultlabel.Visible = true; // Make sure the label is visible
                }

                reader.Close();
                connection.Close();
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
