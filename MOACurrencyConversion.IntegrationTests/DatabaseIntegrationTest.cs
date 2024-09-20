using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;

namespace MOACurrencyConversion.IntegrationTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private readonly string connectionString = "Data Source=(localdb)\\LOCALDB1;Initial Catalog=MOACurrencyConversion;Integrated Security=True";

        [Test, Order(1)]
        public void TestAdminPasswordUpdate()
        {
            // Arrange
            var newPassword = "NewP@ssw0rd123";

            // Act
            bool isUpdated = UpdateAdminPassword("test@gmail.com", newPassword);

            // Assert
            Assert.That(isUpdated, Is.True, "Password update failed.");
        }

        private bool UpdateAdminPassword(string adminEmail, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Admin SET Password = @Password WHERE AdminEmail = @AdminEmail";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@AdminEmail", adminEmail);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating password: {ex.Message}");
                    return false;
                }
            }
        }

        [Test, Order(2)]
        public void TestCreateCurrency()
        {
            // Arrange
            var currencyCode = "USD";
            var currencyName = "United States Dollar";
            var amount = 1.00m;

            // Act
            bool isCreated = CreateCurrency(currencyCode, currencyName, amount);

            // Assert
            Assert.That(isCreated, Is.True, "Currency creation failed.");
        }

        private bool CreateCurrency(string currencyCode, string currencyName, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Currency (CurrencyCode, CurrencyName, Amount) VALUES (@CurrencyCode, @CurrencyName, @Amount)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);
                cmd.Parameters.AddWithValue("@CurrencyName", currencyName);
                cmd.Parameters.AddWithValue("@Amount", amount);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating currency: {ex.Message}");
                    return false;
                }
            }
        }

        [Test, Order(3)]
        public void TestUpdateCurrency()
        {
            // Arrange
            var currencyCode = "USD";
            var newCurrencyName = "US Dollar Updated";
            var newAmount = 1.10m;

            // Act
            bool isUpdated = UpdateCurrency(currencyCode, newCurrencyName, newAmount);

            // Assert
            Assert.That(isUpdated, Is.True, "Currency update failed.");
        }

        private bool UpdateCurrency(string currencyCode, string newCurrencyName, decimal newAmount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Currency SET CurrencyName = @CurrencyName, Amount = @Amount WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);
                cmd.Parameters.AddWithValue("@CurrencyName", newCurrencyName);
                cmd.Parameters.AddWithValue("@Amount", newAmount);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating currency: {ex.Message}");
                    return false;
                }
            }
        }

        [Test, Order(4)]
        public void TestViewCurrency()
        {
            // Arrange
            var currencyCode = "USD";

            // Act
            var currency = ViewCurrency(currencyCode);

            // Assert
            Assert.That(currency, Is.Not.Null, "Currency retrieval failed.");
            Assert.That(currency.CurrencyCode, Is.EqualTo(currencyCode), "Currency code does not match.");
        }

        private Currency ViewCurrency(string currencyCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CurrencyCode, CurrencyName, Amount FROM Currency WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Currency
                            {
                                CurrencyCode = reader["CurrencyCode"].ToString(),
                                CurrencyName = reader["CurrencyName"].ToString(),
                                Amount = Convert.ToDecimal(reader["Amount"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving currency: {ex.Message}");
                    return null;
                }
            }
        }

        [Test, Order(4)]
        public void TestDeleteCurrency()
        {
            // Arrange
            var currencyCode = "USD";

            // Act
            bool isDeleted = DeleteCurrency(currencyCode);

            // Assert
            Assert.That(isDeleted, Is.True, "Currency deletion failed.");
        }

        private bool DeleteCurrency(string currencyCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Currency WHERE CurrencyCode = @CurrencyCode";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CurrencyCode", currencyCode);

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting currency: {ex.Message}");
                    return false;
                }
            }
        }
    }

    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal Amount { get; set; }
    }
}
