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
    public partial class AdminDeleteCurrency : Form
    {
        // Connection string to connect to your SQL Server database
        private readonly string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        public AdminDeleteCurrency()
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

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            string selectedCurrency = SelectcurrencycomboBox.SelectedValue.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Currency WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", selectedCurrency);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Currency deleted successfully!");
                    LoadCurrencies(); // Refresh the ComboBox
                }
                else
                {
                    MessageBox.Show("Failed to delete currency. Please try again.");
                }
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

        private void Updatecurrencylabel_Click(object sender, EventArgs e)
        {
            AdminUpdateCurrency updateCurrencyForm = new AdminUpdateCurrency();
            updateCurrencyForm.Show();
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
