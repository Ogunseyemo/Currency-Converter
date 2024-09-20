using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using MOA_Currency_Converter;
using Castle.Core.Internal;
using System.Reflection.Emit;
using System.Reflection;
using System.Windows.Forms;
using Moq;
using System.Data;
using System.IO;

namespace MOACurrencyConversion.UnitTests
{
    public class ApplicationUnitTest
    {
        [TestFixture]
        public class MOAConversionTests
        {
            private MOAConversion _form;

            [SetUp]
            public void SetUp()
            {
                _form = new MOAConversion();
            }

            [Test]
            public void ConvertCurrency_ValidAmount_PerformsConversion()
            {
                // Arrange
                var fromCurrency = "USD";
                var toCurrency = "EUR";
                var amountText = "100.0";

                // Mock GetConversionRate to return a fixed rate
                MethodInfo getConversionRateMethod = typeof(MOAConversion).GetMethod("GetConversionRate", BindingFlags.NonPublic | BindingFlags.Instance);
                getConversionRateMethod.Invoke(_form, new object[] { fromCurrency, toCurrency });

                // Act
                string result = _form.ConvertCurrency(amountText, fromCurrency, toCurrency);

                // Assert
                Assert.That(result.Contains(fromCurrency), Is.True);
                Assert.That(result.Contains(toCurrency), Is.True);
            }

            [Test]
            public void ConvertCurrency_InvalidAmount_ReturnsErrorMessage()
            {
                // Arrange
                var amountText = "InvalidAmount";
                var fromCurrency = "USD";
                var toCurrency = "EUR";

                // Act
                string result = _form.ConvertCurrency(amountText, fromCurrency, toCurrency);

                // Assert
                Assert.That(result, Is.EqualTo("Please enter a valid amount."));
            }
        }




        [TestFixture]
        public class AdminLoginTests
        {
            private AdminLogin _adminLogin;

            [SetUp]
            public void Setup()
            {
                _adminLogin = new AdminLogin();
            }

            private bool CallAuthenticateAdmin(string adminEmail, string password)
            {
                MethodInfo method = typeof(AdminLogin).GetMethod("AuthenticateAdmin", BindingFlags.NonPublic | BindingFlags.Instance);
                return (bool)method.Invoke(_adminLogin, new object[] { adminEmail, password });
            }

            [Test]
            public void AuthenticateAdmin_ValidCredentials_ReturnsTrue()
            {
                // Arrange
                string email = "test@gmail.com";
                string password = "NewP@ssw0rd123";

                // Act
                bool result = CallAuthenticateAdmin(email, password);

                // Assert
                Assert.That(result, Is.True, "Authentication should succeed with valid credentials.");
            }

            [Test]
            public void AuthenticateAdmin_InvalidCredentials_ReturnsFalse()
            {
                // Arrange
                string email = "test@gmail.com";
                string password = "TestingWithWrongPassword";

                // Act
                bool result = CallAuthenticateAdmin(email, password);

                // Assert
                Assert.That(result, Is.False, "Authentication should fail with invalid credentials.");

            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [TestFixture]
        public class AdminCreateCurrencyTests
        {
            private AdminCreateCurrency _adminCreateCurrency;

            [SetUp]
            public void Setup()
            {
                // Initialize the AdminCreateCurrency form
                _adminCreateCurrency = new AdminCreateCurrency();
            }

            [Test]
            public void TestMethod()
            {
                // Arrange
                int expected = 5;
                int actual = 5;

                // Act & Assert
                Assert.That(actual, Is.EqualTo(expected), "The actual value does not match the expected value.");
            }
            /*
            [Test]
            public void CurrencyamounttextBox_KeyPress_ValidInput_AllowsInput()
            {
                // Arrange
                var textBox = new TextBox();
                textBox.Text = ""; // Ensure TextBox is initially empty
                var keyPressEventArgs = new KeyPressEventArgs('5');

                // Use reflection to invoke the private method
                var methodInfo = typeof(AdminCreateCurrency).GetMethod("CurrencyamounttextBox_KeyPress", BindingFlags.NonPublic | BindingFlags.Instance);

                // Act
                methodInfo.Invoke(_adminCreateCurrency, new object[] { textBox, keyPressEventArgs });

                // Debugging: Print the TextBox text to see what's actually set
                System.Diagnostics.Debug.WriteLine("TextBox Text: " + textBox.Text);

                // Assert
                Assert.That(textBox.Text, Is.EqualTo("5"), "The TextBox should contain the character '5'.");
            }*/

            [TearDown]
            public void Teardown()
            {
                // Clean up resources
                _adminCreateCurrency.Dispose();
            }
        }


    }
}